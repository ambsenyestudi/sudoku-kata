using SudokuKata.Rules.Domain;
using SudokuKata.Rules.Domain.Common;
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
        public void NotBeEmptyWithOneSquare()
        {
            var square = Square.Create(5);
            var sut = new Block();
            sut.Add(square);
            Assert.False(sut.IsEmpty());
        }
    }
}
