using SudokuKata.Rules.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuKata.Rules.Domain
{
    public class Block
    {
        private readonly List<Square> squares = new List<Square>();

        public bool IsEmpty() =>
            !squares.Any();

        public void Add(Square square)
        {
            squares.Add(square);
        }

        public bool IsFull() =>
            squares.Count == Square.MAX_VALUE;
    }
}
