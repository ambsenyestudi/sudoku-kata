using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuKata.Domain.Boards
{
    public class BlockIndexesBuilder
    {
        private readonly int[] squareList;

        public BlockIndexesBuilder(int[] squareList)
        {
            this.squareList = squareList;
        }
        public IEnumerable<IGrouping<int, NamedSquare>> Build()
        {
            return squareList
                    .Select((value, index) => new
                    {
                        Row = index / 9,
                        Column = index % 9,
                        Index = index
                    })
                    .Select(tuple => new NamedSquare
                    {
                        Discriminator = 18 + 3 * (tuple.Row / 3) + tuple.Column / 3,
                        Description = $"block ({tuple.Row / 3 + 1}, {tuple.Column / 3 + 1})",
                        Index = tuple.Index,
                        Row = tuple.Row,
                        Column = tuple.Column
                    }).GroupBy(tuple => tuple.Discriminator);
        }
    }
}
