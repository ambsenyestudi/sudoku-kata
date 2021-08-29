using SudokuKata.Domain.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SudokuKata.Test.Boards
{
    public class LineShould
    {
        [Fact]
        public void True()
        {
            var boardDefintion = BoardDefinition.Create();
            int[] currentState = new int[boardDefintion.SquareCount];
            for (int index = 0; index < currentState.Length; index++)
                if (currentState[index] == 0)
                {

                    int row = index / boardDefintion.Size;
                    int col = index % boardDefintion.Size;
                    int blockRow = row / 3;
                    int blockCol = col / 3;

                    bool[] isDigitUsed = new bool[boardDefintion.Size];
                    for (int i = 0; i < boardDefintion.Size; i++)
                    {
                        //sweaps board column wise
                        //this is square index not row index
                        var rowWiseSquareIndex = boardDefintion.ToBoardIndex(boardDefintion.Size * i, col);
                        int rowIndex = boardDefintion.Size * i + col;
                        int rowDigit = currentState[rowIndex];
                        if (rowDigit > 0)
                            isDigitUsed[rowDigit - 1] = true;

                        //sweaps board row wise
                        var colWiseSquareIndex = boardDefintion.ToBoardIndex(boardDefintion.Size * row, i );
                        int colIndex = boardDefintion.Size * row + i;
                        int colDigit = currentState[colIndex];
                        if (colDigit > 0)
                            isDigitUsed[colDigit - 1] = true;
                        //and per each block of nine
                        var blockIndex = (blockRow * 3 + i / 3) * boardDefintion.Size + (blockCol * 3 + i % 3);
                        int blockDigit = currentState[blockIndex];
                        if (blockDigit > 0)
                            isDigitUsed[blockDigit - 1] = true;
                    } // for (i = 0..8)
                }
            Assert.True(true);
        }
    }
}
