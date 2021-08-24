using System;

namespace SudokuKata.Domain.Boards
{
    public record BoardDefinition
    {
        public int Size { get; }
        public int SquareCount { get; }

        private BoardDefinition(int size = 9)
        {
            Size = size;
            SquareCount = Size * Size;
        }
        public static BoardDefinition Create(int size)
        {
            return null;
        }
    }
}
