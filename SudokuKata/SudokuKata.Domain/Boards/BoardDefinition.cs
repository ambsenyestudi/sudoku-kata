using System;

namespace SudokuKata.Domain.Boards
{
    public record BoardDefinition
    {
        public static int DEFAULT_SIZE = 9;
        public int Size { get; }
        public int SquareCount { get; }

        private BoardDefinition(int size = 9)
        {
            Size = size;
            SquareCount = Size * Size;
        }

        public int ToBoardIndex(int row, int column) =>
            (row * Size) + column;

        public (int, int) ToRowColumn(int index) =>
            (index / Size, index % Size);

        
            

        public static BoardDefinition Create(int size)
        {
            if(size<1)
            {
                throw new ArgumentException($"Invalid {nameof(size)} for {nameof(BoardDefinition)}");
            }
            return new BoardDefinition(size);
        }

        public static BoardDefinition Create() =>
            Create(DEFAULT_SIZE);
    }
}
