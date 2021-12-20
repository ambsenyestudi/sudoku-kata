using System.Collections.Generic;
using System.Linq;

namespace SudokuKata.Domain.Boards
{
    public class ColumnIndexesBuilder
    {
        private readonly int[] squareList;

        public ColumnIndexesBuilder(int[] squareList)
        {
            this.squareList = squareList;
        }
        public IEnumerable<IGrouping<int, NamedSquare>> Build()
        {
            return squareList
                    .Select((value, index) => new NamedSquare
                    {
                        Discriminator = 9 + index % 9,
                        Description = $"column #{index % 9 + 1}",
                        Index = index,
                        Row = index / 9,
                        Column = index % 9
                    })
                    .GroupBy(tuple => tuple.Discriminator);
        }
    }
}
