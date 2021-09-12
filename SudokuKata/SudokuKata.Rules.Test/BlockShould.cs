using SudokuKata.Rules.Domain;
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
    }
}
