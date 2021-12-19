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
        public void Start_As()
        {
            var sut = new Game(outputServiceMock.Object);
            sut.Play();
            outputServiceMock
                .Verify(x => x.Print(string.Empty,
                "Final look of the solved board:"),
                Times.Once);
        }

        [Fact]
        public void Present_Start_Board_As()
        {
            var sut = new Game(outputServiceMock.Object);
            sut.Play();
            outputServiceMock
                .Verify(x => x.Print(string.Empty,
                "Starting look of the board to solve:"),
                Times.Once);
        }
    }
}
