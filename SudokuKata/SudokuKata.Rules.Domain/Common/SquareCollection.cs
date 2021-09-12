using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuKata.Rules.Domain.Common
{
    public record SquareCollection
    {
        public static SquareCollection Empty { get; } = new SquareCollection(new int[0]);
        private readonly int[] squareValues;

        private SquareCollection(int[] squareValues) => this.squareValues = squareValues;

        public SquareCollection Add(Square square)
        {
            if(square == Square.Empty)
            {
                return this;
            }

            var valueList = new List<int>(squareValues);
            valueList.Add(square.Value);

            return new SquareCollection(valueList.ToArray());
        }

        public bool Contains(Square square) =>
            squareValues.Contains(square.Value);

        public bool IsFull() =>
            squareValues.Length == Square.MAX_VALUE;
    }
}
