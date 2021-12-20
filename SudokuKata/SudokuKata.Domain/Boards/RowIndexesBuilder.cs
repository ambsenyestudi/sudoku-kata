using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuKata.Domain.Boards
{
    public class RowIndexesBuilder
    {
        private readonly int[] squareList;

        public RowIndexesBuilder(int[] squareList)
        {
            this.squareList = squareList;
        }
        public IEnumerable<IGrouping<int,NamedSquare>> Build()
        {
            return squareList
                    .Select((value, index) => new NamedSquare
                    {
                        Discriminator = index / 9,
                        Description = $"row #{index / 9 + 1}",
                        Index = index,
                        Row = index / 9,
                        Column = index % 9
                    })
                    .GroupBy(tuple => tuple.Discriminator);
        }
    }
}
