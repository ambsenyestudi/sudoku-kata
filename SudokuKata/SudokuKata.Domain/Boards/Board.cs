using SudokuKata.Domain.Randomizing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuKata.Domain.Boards
{
    public class Board
    {
        private const string LINE = "+---+---+---+";
        private const string MIDDLE = "|...|...|...|";
        public char[][] Squares { get; }

        public Board()
        {

            Squares = CreateEmptyBoardDisplay();
        }

        public char[][] ConstructFullyPopulatedBoard(
            string command, 
            IRandomService randomService,
            Stack<int[]> stateStack,
            Stack<int> rowIndexStack,
            Stack<int> colIndexStack,
            Stack<bool[]> usedDigitsStack,
            Stack<int> lastDigitStack)
        {
            char[][] squares = CreateEmptyBoardDisplay();
            while (stateStack.Count <= 9 * 9)
            {
                if (command == "expand")
                {
                    int[] currentState = new int[9 * 9];

                    if (stateStack.Count > 0)
                    {
                        Array.Copy(stateStack.Peek(), currentState, currentState.Length);
                    }

                    int bestRow = -1;
                    int bestCol = -1;
                    bool[] bestUsedDigits = null;
                    int bestCandidatesCount = -1;
                    int bestRandomValue = -1;
                    bool containsUnsolvableCells = false;

                    for (int index = 0; index < currentState.Length; index++)
                        if (currentState[index] == 0)
                        {

                            int row = index / 9;
                            int col = index % 9;
                            int blockRow = row / 3;
                            int blockCol = col / 3;

                            bool[] isDigitUsed = new bool[9];

                            for (int i = 0; i < 9; i++)
                            {
                                int rowDigit = currentState[9 * i + col];
                                if (rowDigit > 0)
                                    isDigitUsed[rowDigit - 1] = true;

                                int colDigit = currentState[9 * row + i];
                                if (colDigit > 0)
                                    isDigitUsed[colDigit - 1] = true;

                                int blockDigit = currentState[(blockRow * 3 + i / 3) * 9 + (blockCol * 3 + i % 3)];
                                if (blockDigit > 0)
                                    isDigitUsed[blockDigit - 1] = true;
                            } // for (i = 0..8)

                            int candidatesCount = isDigitUsed.Where(used => !used).Count();

                            if (candidatesCount == 0)
                            {
                                containsUnsolvableCells = true;
                                break;
                            }

                            int randomValue = randomService.Next();

                            if (bestCandidatesCount < 0 ||
                                candidatesCount < bestCandidatesCount ||
                                (candidatesCount == bestCandidatesCount && randomValue < bestRandomValue))
                            {
                                bestRow = row;
                                bestCol = col;
                                bestUsedDigits = isDigitUsed;
                                bestCandidatesCount = candidatesCount;
                                bestRandomValue = randomValue;
                            }

                        } // for (index = 0..81)

                    if (!containsUnsolvableCells)
                    {
                        stateStack.Push(currentState);
                        rowIndexStack.Push(bestRow);
                        colIndexStack.Push(bestCol);
                        usedDigitsStack.Push(bestUsedDigits);
                        lastDigitStack.Push(0); // No digit was tried at this position
                    }

                    // Always try to move after expand
                    command = "move";

                } // if (command == "expand")
                else if (command == "collapse")
                {
                    stateStack.Pop();
                    rowIndexStack.Pop();
                    colIndexStack.Pop();
                    usedDigitsStack.Pop();
                    lastDigitStack.Pop();

                    command = "move";   // Always try to move after collapse
                }
                else if (command == "move")
                {

                    int rowToMove = rowIndexStack.Peek();
                    int colToMove = colIndexStack.Peek();
                    int digitToMove = lastDigitStack.Pop();

                    int rowToWrite = rowToMove + rowToMove / 3 + 1;
                    int colToWrite = colToMove + colToMove / 3 + 1;

                    bool[] usedDigits = usedDigitsStack.Peek();
                    int[] currentState = stateStack.Peek();
                    int currentStateIndex = 9 * rowToMove + colToMove;

                    int movedToDigit = digitToMove + 1;
                    while (movedToDigit <= 9 && usedDigits[movedToDigit - 1])
                        movedToDigit += 1;

                    if (digitToMove > 0)
                    {
                        usedDigits[digitToMove - 1] = false;
                        currentState[currentStateIndex] = 0;
                        squares[rowToWrite][colToWrite] = '.';
                    }

                    if (movedToDigit <= 9)
                    {
                        lastDigitStack.Push(movedToDigit);
                        usedDigits[movedToDigit - 1] = true;
                        currentState[currentStateIndex] = movedToDigit;
                        squares[rowToWrite][colToWrite] = (char)('0' + movedToDigit);

                        // Next possible digit was found at current position
                        // Next step will be to expand the state
                        command = "expand";
                    }
                    else
                    {
                        // No viable candidate was found at current position - pop it in the next iteration
                        lastDigitStack.Push(0);
                        command = "collapse";
                    }
                }

            }
            return squares;
        }


        public char[][] GenerateInitialBoardFrom(int[] state,
            char[][] squares,
            IRandomService randomService)
        {
            int remainingDigits = 30;
            int maxRemovedPerBlock = 6;
            int[,] removedPerBlock = new int[3, 3];
            int[] positions = Enumerable.Range(0, 9 * 9).ToArray();
         
            
            //shift squares around until you get 30 removed squares
            int removedPos = 0;
            while (removedPos < 9 * 9 - remainingDigits)
            {
                //stores the total amount of removed digits
                int curRemainingDigits = positions.Length - removedPos;
                //generate random index
                int indexToPick = removedPos + randomService.Next(curRemainingDigits);

                //traansform to board coordenates
                int row = positions[indexToPick] / 9;
                int col = positions[indexToPick] % 9;

                //what block it operates on
                int blockRowToRemove = row / 3;
                int blockColToRemove = col / 3;

                //ensure that enought squares are left for the user to play
                if (removedPerBlock[blockRowToRemove, blockColToRemove] >= maxRemovedPerBlock)
                    continue;
                //keep count of blocks removed
                removedPerBlock[blockRowToRemove, blockColToRemove] += 1;

                //shits arround the current index value and the new value chosen for removal
                int temp = positions[removedPos];
                positions[removedPos] = positions[indexToPick];
                positions[indexToPick] = temp;
                
                int rowToWrite = row + row / 3 + 1;
                int colToWrite = col + col / 3 + 1;

                squares[rowToWrite][colToWrite] = '.';
                
                int stateIndex = 9 * row + col;
                state[stateIndex] = 0;

                removedPos += 1;
            }
            return squares;
        }
        public static char[][] PaintState(int[] state)
        {
            var boardDisplay = CreateEmptyBoardDisplay();
            int max = 9 * 9;
            for (int i = 0; i < max; i++)
            {
                var pos = new BoardPosition(i);
                var (displayRow, displayCol) = pos.ToRowCol();
                boardDisplay[displayRow][displayCol] = NumberAsChar(state[i]);
            }
            return boardDisplay;
        }
        private static char NumberAsChar(int i) =>
            ("" + i).ToCharArray()[0];
        private static char[][] CreateEmptyBoardDisplay()
        {
            return new char[][]
            {
                LINE.ToCharArray(),
                MIDDLE.ToCharArray(),
                MIDDLE.ToCharArray(),
                MIDDLE.ToCharArray(),
                LINE.ToCharArray(),
                MIDDLE.ToCharArray(),
                MIDDLE.ToCharArray(),
                MIDDLE.ToCharArray(),
                LINE.ToCharArray(),
                MIDDLE.ToCharArray(),
                MIDDLE.ToCharArray(),
                MIDDLE.ToCharArray(),
                LINE.ToCharArray()
            };
        }
    }
}
