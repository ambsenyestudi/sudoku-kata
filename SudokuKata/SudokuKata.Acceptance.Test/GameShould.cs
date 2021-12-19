using Moq;
using SudokuKata.Domain.Boards;
using System;
using Xunit;

namespace SudokuKata.Acceptance.Test
{
    public class GameShould
    {
        private readonly Mock<IOutputService> outputServiceMock;
        private readonly Mock<IRandomService> randomServiceMock;
        private readonly Board BOARD = new Board();
        public GameShould()
        {
            outputServiceMock = new Mock<IOutputService>();
            randomServiceMock = new Mock<IRandomService>();
        }
        [Fact]
        public void Start_As()
        {
            var sut = new Game(
                BOARD,
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
                BOARD,
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
                BOARD,
                outputServiceMock.Object,
                randomServiceMock.Object);
            randomServiceMock.Setup(x => x.Next()).Returns(zeroSeed);
            randomServiceMock.Setup(x => x.Next(It.IsAny<int>()))
                .Returns((int i) => new Random().Next(i));
            sut.Play();
            outputServiceMock
                .Verify(x => x.Print(exptected),
                Times.AtLeastOnce);
        }

        [Fact]
        public void Have_Separator()
        {
            var expected = new string('=', 80);
            var sut = new Game(
                BOARD,
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

        [Theory]
        [InlineData("Code: 000006009056780000009100406031000805000012000600508007017265948002000030060000000")]
        [InlineData("Code: 000006009056780000009100406031000805000012000604508007017265948002000030060000000")]
        [InlineData("Code: 000006009056780000009103406031000805000012000604508007017265948002000030060000000")]
        [InlineData("Code: 000006009056780000009103406031000805000012000604508007317265948002000030060000000")]
        [InlineData("Code: 000406009056780000009103406031000805000012000604508007317265948002000030060000000")]
        [InlineData("Code: 000406009056789000009103406031000805000012000604508007317265948002000030060000000")]
        [InlineData("Code: 000406009056789000009103406031000805000012000604508007317265948002000031060000000")]
        [InlineData("Code: 000406009056789000009103406031000805000012000604508007317265948002000031060000002")]
        [InlineData("Code: 000406009056789003009103406031000805000012000604508007317265948002000031060000002")]
        [InlineData("Code: 000406009056789003009103406031000805000012004604508007317265948002000031060000002")]
        [InlineData("Code: 000406009056789003009103406031000805000012004604508007317265948002000631060000002")]
        [InlineData("Code: 000406009056789003009103406031000805000012304604508007317265948002000631060000002")]
        [InlineData("Code: 000406009056789003009103406031000805000012304604508007317265948042000631060000002")]
        [InlineData("Code: 000406009056789003009103406031000805000012304604508007317265948042007631060000002")]
        [InlineData("Code: 000406009056789003009103406031000805000012304604508007317265948042097631060000002")]
        [InlineData("Code: 000406009056789003009103406031000805000012304604538007317265948042097631060000002")]
        [InlineData("Code: 000406009056789003009103406031004805000012304604538007317265948042097631060000002")]
        [InlineData("Code: 000406009056789003009103406031004805000012304604538007317265948042097631060001002")]
        [InlineData("Code: 000406009056789003009103406031074805000012304604538007317265948042097631060001002")]
        [InlineData("Code: 000406009056789003009103406031074805000012304604538007317265948042097631060041002")]
        [InlineData("Code: 000406009056789003009103406031074805000012304604538007317265948042897631060041002")]
        [InlineData("Code: 000406009056789003009103406031074805000012304604538007317265948042897631060341002")]
        [InlineData("Code: 000406009056789003009103406031074805000012304604538007317265948542897631060341002")]
        [InlineData("Code: 000406009056789003009103406031074805000012304604538007317265948542897631068341002")]
        [InlineData("Code: 003406009056789003009103406031074805000012304604538007317265948542897631068341002")]
        [InlineData("Code: 003406009056789003009103406031074805005012304604538007317265948542897631068341002")]
        [InlineData("Code: 003406009056789003009103406031074805005012304604538007317265948542897631968341002")]
        [InlineData("Code: 003406009056789003009103406231074805005012304604538007317265948542897631968341002")]
        [InlineData("Code: 003406009056789003009103406231074805005012304694538007317265948542897631968341002")]
        [InlineData("Code: 003406009456789003009103406231074805005012304694538007317265948542897631968341002")]
        [InlineData("Code: 103406009456789003009103406231074805005012304694538007317265948542897631968341002")]
        [InlineData("Code: 103406009456789003009103406231074895005012364694538007317265948542897631968341002")]
        [InlineData("Code: 103406009456789003009103406231674895005012364694538007317265948542897631968341002")]
        [InlineData("Code: 103406009456789003009103406231674895005912364694538007317265948542897631968341002")]
        [InlineData("Code: 103456009456789003009123406231674895005912364694538007317265948542897631968341002")]
        [InlineData("Code: 103456009456789003009123406231674895005912364694538007317265948542897631968341502")]
        [InlineData("Code: 103456009456789003009123406231674895005912364694538007317265948542897631968341572")]
        [InlineData("Code: 103456009456789003009123456231674895005912364694538007317265948542897631968341572")]
        [InlineData("Code: 103456089456789003009123456231674895005912364694538007317265948542897631968341572")]
        [InlineData("Code: 123456089456789003009123456231674895005912364694538007317265948542897631968341572")]
        [InlineData("Code: 123456789456789003009123456231674895005912364694538007317265948542897631968341572")]
        [InlineData("Code: 123456789456789123009123456231674895005912364694538007317265948542897631968341572")]
        [InlineData("Code: 123456789456789123009123456231674895005912364694538017317265948542897631968341572")]
        [InlineData("Code: 123456789456789123009123456231674895005912364694538217317265948542897631968341572")]
        [InlineData("Code: 123456789456789123009123456231674895875912364694538217317265948542897631968341572")]
        [InlineData("Code: 123456789456789123089123456231674895875912364694538217317265948542897631968341572")]
        [InlineData("Code: 123456789456789123789123456231674895875912364694538217317265948542897631968341572")]
        public void Have_Expected_Play_Codes(string expected)
        {
            var sut = new Game(
                BOARD,
                outputServiceMock.Object,
                randomServiceMock.Object);
            randomServiceMock.Setup(x => x.Next()).Returns(0);
            var random = new Random(5);
            randomServiceMock.Setup(x => x.Next(It.IsAny<int>()))
                .Returns((int i) => random.Next(i));
            sut.Play();
            outputServiceMock
                .Verify(x => x.Print(expected,
                string.Empty),
                Times.Once);
        }
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void Present_Current_Board_As(int outputIndex)
        {
            var expected = play_outputs[outputIndex];
            var zeroSeed = 0;
            var sut = new Game(
                BOARD,
                outputServiceMock.Object,
                randomServiceMock.Object);
            randomServiceMock.Setup(x => x.Next()).Returns(zeroSeed);
            var random = new Random(5);
            randomServiceMock.Setup(x => x.Next(It.IsAny<int>()))
                .Returns((int i) => random.Next(i));
            sut.Play();
            outputServiceMock
                .Verify(x => x.Print(expected),
                Times.Once);
        }
        private string[] play_outputs = new string[]
        {
            string.Join(Environment.NewLine,
                new string[]{
                    "+---+---+---+",
                    "|...|..6|..9|",
                    "|.56|78.|...|",
                    "|..9|1..|4.6|",
                    "+---+---+---+",
                    "|.31|...|8.5|",
                    "|...|.12|...|",
                    "|6..|5.8|..7|",
                    "+---+---+---+",
                    "|.17|265|94.|",
                    "|..2|...|.3.|",
                    "|.6.|...|...|",
                    "+---+---+---+"
                }),
            string.Join(Environment.NewLine,
                new string[]{
                    "+---+---+---+",
                    "|...|..6|..9|",
                    "|.56|78.|...|",
                    "|..9|1..|4.6|",
                    "+---+---+---+",
                    "|.31|...|8.5|",
                    "|...|.12|...|",
                    "|6..|5.8|..7|",
                    "+---+---+---+",
                    "|.17|265|948|",
                    "|..2|...|.3.|",
                    "|.6.|...|...|",
                    "+---+---+---+"
                }),
            string.Join(Environment.NewLine,
                new string[]{
                    "+---+---+---+",
                    "|...|..6|..9|",
                    "|.56|78.|...|",
                    "|..9|1..|4.6|",
                    "+---+---+---+",
                    "|.31|...|8.5|",
                    "|...|.12|...|",
                    "|6.4|5.8|..7|",
                    "+---+---+---+",
                    "|.17|265|948|",
                    "|..2|...|.3.|",
                    "|.6.|...|...|",
                    "+---+---+---+"
                }),
            string.Join(Environment.NewLine,
                new string[]{
                    "+---+---+---+",
                    "|...|..6|..9|",
                    "|.56|78.|...|",
                    "|..9|1.3|4.6|",
                    "+---+---+---+",
                    "|.31|...|8.5|",
                    "|...|.12|...|",
                    "|6.4|5.8|..7|",
                    "+---+---+---+",
                    "|.17|265|948|",
                    "|..2|...|.3.|",
                    "|.6.|...|...|",
                    "+---+---+---+"
                }),
            string.Join(Environment.NewLine,
                new string[]{
                    "+---+---+---+",
                    "|...|..6|..9|",
                    "|.56|78.|...|",
                    "|..9|1.3|4.6|",
                    "+---+---+---+",
                    "|.31|...|8.5|",
                    "|...|.12|...|",
                    "|6.4|5.8|..7|",
                    "+---+---+---+",
                    "|317|265|948|",
                    "|..2|...|.3.|",
                    "|.6.|...|...|",
                    "+---+---+---+"
                }),
            string.Join(Environment.NewLine,
                new string[]{
                    "+---+---+---+",
                    "|...|4.6|..9|",
                    "|.56|78.|...|",
                    "|..9|1.3|4.6|",
                    "+---+---+---+",
                    "|.31|...|8.5|",
                    "|...|.12|...|",
                    "|6.4|5.8|..7|",
                    "+---+---+---+",
                    "|317|265|948|",
                    "|..2|...|.3.|",
                    "|.6.|...|...|",
                    "+---+---+---+"
                }),
            string.Join(Environment.NewLine,
                new string[]{
                    "+---+---+---+",
                    "|...|4.6|..9|",
                    "|.56|789|...|",
                    "|..9|1.3|4.6|",
                    "+---+---+---+",
                    "|.31|...|8.5|",
                    "|...|.12|...|",
                    "|6.4|5.8|..7|",
                    "+---+---+---+",
                    "|317|265|948|",
                    "|..2|...|.3.|",
                    "|.6.|...|...|",
                    "+---+---+---+"
                }),
        };
    }

}
