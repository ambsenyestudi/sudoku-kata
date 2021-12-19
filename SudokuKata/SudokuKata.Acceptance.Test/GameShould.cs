using Moq;
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
        [Fact]
        public void Start_As()
        {
            var sut = new Game(
                outputServiceMock.Object, 
                randomServiceMock.Object);
            randomServiceMock.Setup(x => x.Next()).Returns(new Random().Next());
            randomServiceMock.Setup(x => x.Next(It.IsAny<int>()))
                .Returns((int i) => new Random().Next(i));
            sut.Play();
            outputServiceMock
                .Verify(x => x.Print(string.Empty,
                "Final look of the solved board:"),
                Times.Once);
        }

        [Fact]
        public void Present_Start_Board_As()
        {
            var sut = new Game(
                outputServiceMock.Object,
                randomServiceMock.Object);
            randomServiceMock.Setup(x => x.Next()).Returns(new Random().Next());
            randomServiceMock.Setup(x => x.Next(It.IsAny<int>()))
                .Returns((int i) => new Random().Next(i));
            sut.Play();
            outputServiceMock
                .Verify(x => x.Print(string.Empty,
                "Starting look of the board to solve:"),
                Times.Once);
        }
        /*
         * Seeded with 0 
            +---+---+---+
            |123|456|789|
            |456|789|123|
            |789|123|456|
            +---+---+---+
            |231|674|895|
            |875|912|364|
            |694|538|217|
            +---+---+---+
            |317|265|948|
            |542|897|631|
            |968|341|572|
            +---+---+---+
         */
        [Fact]
        public void Present_Final_Board_As()
        {
            var exptected = "+---+---+---+" + Environment.NewLine +
                "|123|456|789|" + Environment.NewLine +
                "|456|789|123|" + Environment.NewLine +
                "|789|123|456|" + Environment.NewLine +
                "+---+---+---+" + Environment.NewLine +
                "|231|674|895|" + Environment.NewLine +
                "|875|912|364|" + Environment.NewLine +
                "|694|538|217|" + Environment.NewLine +
                "+---+---+---+" + Environment.NewLine +
                "|317|265|948|" + Environment.NewLine +
                "|542|897|631|" + Environment.NewLine +
                "|968|341|572|" + Environment.NewLine +
                "+---+---+---+";
            var zeroSeed = 0;
            var sut = new Game(
                outputServiceMock.Object,
                randomServiceMock.Object);
            randomServiceMock.Setup(x => x.Next()).Returns(zeroSeed);
            randomServiceMock.Setup(x => x.Next(It.IsAny<int>()))
                .Returns((int i) => new Random().Next(i));
            sut.Play();
            outputServiceMock
                .Verify(x => x.Print(exptected),
                Times.Once);
        }
        
        [Fact]
        public void Have_separator()
        {
            var expected = new string('=', 80);
            var sut = new Game(
                outputServiceMock.Object,
                randomServiceMock.Object);
            randomServiceMock.Setup(x => x.Next()).Returns(new Random().Next());
            randomServiceMock.Setup(x => x.Next(It.IsAny<int>()))
                .Returns((int i) => new Random().Next(i));
            sut.Play();
            outputServiceMock
                .Verify(x => x.Print(string.Empty,
                expected,
                string.Empty),
                Times.Once);
        }

    }
}
