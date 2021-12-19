using Moq;
using System;
using Xunit;

namespace SudokuKata.Acceptance.Test
{
    public class GameShould
    {
        private readonly Mock<IOutputService> outputServiceMock;

        public GameShould()
        {
            outputServiceMock = new Mock<IOutputService>();
        }
        [Fact]
        public void Start_Printing()
        {
            var sut = new Game(outputServiceMock.Object);
            sut.Play();
            outputServiceMock
                .Verify(x => x.Print(string.Empty,
                "Final look of the solved board:"),
                Times.Once);
        }
    }
}
