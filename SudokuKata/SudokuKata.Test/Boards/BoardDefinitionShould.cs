using SudokuKata.Domain.Boards;
using System;
using Xunit;

namespace SudokuKata.Test.Boards
{
    public class BoardDefinitionShould
    {
        [Fact]
        public void HaveSquares()
        {
            Assert.Throws<ArgumentException>(()=> BoardDefinition.Create(0));
        }
        [Fact]
        public void DefaultSize()
        {
            var sut = BoardDefinition.Create();
            Assert.NotNull(sut);
        }
    }
}
