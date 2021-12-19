namespace SudokuKata.Domain.Boards
{
    public class Board
    {
        private readonly string line = "+---+---+---+";
        private readonly string middle = "|...|...|...|";
        private char[][] board;
        public Board()
        {
            board = new BoardLayoutBuilder(line)
                .WithBlocks(middle, middle, middle)
                .Build();
        }
        public char[][] GetBoard() => board;
    }
}
