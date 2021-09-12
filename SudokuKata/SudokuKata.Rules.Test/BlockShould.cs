using SudokuKata.Rules.Domain;
using SudokuKata.Rules.Domain.Common;
using System;
using System.Collections.Generic;
using Xunit;

namespace SudokuKata.Rules.Test
{
    public class BlockShould
    {
        [Fact]
        public void StartEmpty()
        {
            var sut = new Block();
            Assert.True(sut.IsEmpty());
        }

        [Fact]
        public void RemainsEmptyWhenEmptySquareAdde()
        {
            var sut = new Block();
            sut.Add(Square.Empty);
            Assert.True(sut.IsEmpty());
        }

        [Fact]
        public void NotBeEmptyWithOneSquare()
        {
            var square = Square.Create(5);
            var sut = new Block();
            sut.Add(square);
            Assert.False(sut.IsEmpty());
        }

        [Fact]
        public void FullWhenAllPositionsAdded()
        {
            var sut = new Block();
            for (int i = 0; i < Square.MAX_VALUE; i++)
            {
                sut.Add(Square.Create(i + 1));
            }
            Assert.True(sut.IsFull());
        }

        [Fact]
        public void NotHaveRepatedValues()
        {
            var squareValue = 5;
            var square = Square.Create(squareValue);
            var sut = new Block();
            sut.Add(square);
            var repeatedSquare = Square.Create(squareValue);
            
            Assert.Throws<ArgumentException>(()=> sut.Add(repeatedSquare));
        }
    }
}