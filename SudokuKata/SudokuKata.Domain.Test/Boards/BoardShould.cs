using Moq;
using SudokuKata.Domain.Boards;
using SudokuKata.Domain.Randomizing;
using System;
using System.Linq;
using Xunit;

namespace SudokuKata.Domain.Test
{
    public class BoardShould
    {
        private readonly Mock<IRandomService> randomServiceMock;
                
        private readonly int[] STATE=new int[]
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9,
            4, 5, 6, 7, 8, 9, 1, 2, 3,
            7, 8, 9, 1, 2, 3, 4, 5, 6 ,
            
            2, 3, 1, 6, 7, 4, 8, 9, 5,
            8, 7, 5, 9, 1, 2, 3, 6, 4,
            6, 9, 4, 5, 3, 8, 2, 1, 7,
            
            3, 1, 7, 2, 6, 5, 9, 4, 8,
            5, 4, 2, 8, 9, 7, 6, 3, 1,
            9, 6, 8, 3, 4, 1, 5, 7, 2
        };

        public BoardShould()
        {
            randomServiceMock = new Mock<IRandomService>();
        }

        [Fact]
        public void PaintSate()
        {
            var solvedBoard = Board.PaintState(STATE);
            var expectedDisplay = new string[]{
                "+---+---+---+",
                "|123|456|789|",
                "|456|789|123|",
                "|789|123|456|",
                "+---+---+---+",
                "|231|674|895|",
                "|875|912|364|",
                "|694|538|217|",
                "+---+---+---+",
                "|317|265|948|",
                "|542|897|631|",
                "|968|341|572|",
                "+---+---+---+",
            };
            var actualDisplay = solvedBoard.Select(x => new string(x)).ToArray();
            Assert.Equal(expectedDisplay, actualDisplay);
        }

    }
}
