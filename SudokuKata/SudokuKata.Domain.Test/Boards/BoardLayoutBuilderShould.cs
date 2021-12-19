using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
