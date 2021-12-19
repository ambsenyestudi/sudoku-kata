using ApprovalTests;
using ApprovalTests.Reporters;
using Moq;
using SudokuKata.Domain.Randomizing;
using System;
using Xunit;

namespace SudokuKata.Acceptance.Test
{
    public class GameShould
    {
        private readonly Mock<IOutputService> outputServiceMock;
        private readonly Mock<IRandomService> randomServiceMock;

        public GameShould()
        {
            outputServiceMock = new Mock<IOutputService>();
            randomServiceMock = new Mock<IRandomService>();
        }

        [UseReporter(typeof(VisualStudioReporter))]
        [Fact]
        public void GetOutput()
        {

            randomServiceMock.Setup(x => x.Next()).Returns(0);
            var random = new Random(5);
            randomServiceMock.Setup(x => x.Next(It.IsAny<int>()))
                .Returns((int i) => random.Next(i));

            var sut = new Game(randomServiceMock.Object);
            var actual = sut.Play();
            Approvals.VerifyAll(actual, "");
        }

    }

}
