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
    }
}
