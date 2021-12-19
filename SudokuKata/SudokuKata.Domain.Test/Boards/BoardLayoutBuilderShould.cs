using SudokuKata.Domain.Boards;
using Xunit;

namespace SudokuKata.Domain.Test.Boards
{
    public class BoardLayoutBuilderShould
    {
        [Fact]
        public void Empty_When_No_Blocks()
        {
            var sut = new BoardLayoutBuilder();
            Assert.Equal(new char[][] { }, sut.Build());
        }
        [Fact]
        public void Have_Blocks_And_Separator()
        {
            var exptected = new char[][]
               {
                    "+---+---+---+".ToCharArray(),
                    "|...|...|...|".ToCharArray(),
                    "|...|...|...|".ToCharArray(),
                    "|...|...|...|".ToCharArray(),
                    "+---+---+---+".ToCharArray(),
                    "|...|...|...|".ToCharArray(),
                    "|...|...|...|".ToCharArray(),
                    "|...|...|...|".ToCharArray(),
                    "+---+---+---+".ToCharArray(),
                    "|...|...|...|".ToCharArray(),
                    "|...|...|...|".ToCharArray(),
                    "|...|...|...|".ToCharArray(),
                    "+---+---+---+".ToCharArray(),
               };
            var sut = new BoardLayoutBuilder()
                .WithBlocks("|...|...|...|", "|...|...|...|", "|...|...|...|");
            var actual = sut.Build();
           
            Assert.Equal(exptected, actual);
        }
    }
}
