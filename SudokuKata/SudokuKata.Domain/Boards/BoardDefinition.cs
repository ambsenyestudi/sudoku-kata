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
        public static BoardDefinition Create(int size)
        {
            if(size<1)
            {
                throw new ArgumentException($"Invalid {nameof(size)} for {nameof(BoardDefinition)}");
            }
            return null;
        }

        public static BoardDefinition Create() =>
            Create(DEFAULT_SIZE);
    }
}
