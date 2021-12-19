using System.Linq;

namespace SudokuKata.Domain.Boards
{
    public class BoardLayoutBuilder
    {
        
        private string lineseparator = string.Empty;
        private string[] blocks = new string[0];

        public BoardLayoutBuilder(string lineseparator = "+---+---+---+")
        {
            this.lineseparator = lineseparator;
        }
        public BoardLayoutBuilder(params string [] newBlocks)
        {
            this.blocks = newBlocks;
        }
        public char[][] Build()
        {
            if(!blocks.Any())
            {
                return new char[][] { };
            }
            return null;
        }

    }
}
