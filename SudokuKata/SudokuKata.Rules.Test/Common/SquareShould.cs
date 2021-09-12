using SudokuKata.Rules.Domain.Common;
using Xunit;

namespace SudokuKata.Rules.Test.Common
{
    public class SquareShould
    {
        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        public void BeEmptyWhenInvalidValue(int value)
        {
            var expected = Square.Empty;
            var actual = Square.Create(value);
            Assert.Equal(expected, actual);
        }
    }
}
