using System;
using System.Linq;

namespace SudokuKata
{
    public class BoardBuilder
    {
        private char[][] rows;

        public BoardBuilder WithRows(char[][] inputRows)
        {
            rows = inputRows;
            return this;
        }
        public string Build() =>
            string.Join(Environment.NewLine, rows.Select(s => new string(s)));

    }
}
