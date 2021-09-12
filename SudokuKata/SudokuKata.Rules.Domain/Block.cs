using SudokuKata.Rules.Domain.Common;
using System;

namespace SudokuKata.Rules.Domain
{
    public class Block
    {
        private SquareCollection squareCollection = SquareCollection.Empty;

        public bool IsEmpty() =>
            squareCollection == SquareCollection.Empty;

        public void Add(Square square)
        {
            if(squareCollection.Contains(square))
            {
                throw new ArgumentException();
            }
            squareCollection = squareCollection.Add(square);
        }

        public bool IsFull() =>
            squareCollection.IsFull();
    }
}
