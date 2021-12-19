using System.Collections.Generic;
using System.Linq;

namespace SudokuKata.Domain.Boards
{
    public class BoardLayoutBuilder
    {
        private const int NUMBER_OF_BLOCKS = 3;
        private string lineseparator = string.Empty;
        private string[] blocks = new string[0];

        public BoardLayoutBuilder(string lineseparator = "+---+---+---+")
        {
            this.lineseparator = lineseparator;
        }
        public BoardLayoutBuilder WithBlocks(params string [] newBlocks)
        {
            this.blocks = newBlocks;
            return this;
        }
        public char[][] Build()
        {
            if(!blocks.Any())
            {
                return new char[][] { };
            }
            var result = new List<char[]>();
            for (int i = 0; i < NUMBER_OF_BLOCKS; i++)
            {
                result.Add(lineseparator.ToCharArray());
                result.AddRange(blocks.Select(x => x.ToCharArray()));
            }
            result.Add(lineseparator.ToCharArray());
            return result.ToArray();
        }

    }
}
