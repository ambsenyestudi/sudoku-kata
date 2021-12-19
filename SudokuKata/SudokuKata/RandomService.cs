using SudokuKata.Domain.Randomizing;
using System;

namespace SudokuKata
{
    public class RandomService : IRandomService
    {
        public readonly Random random = new Random();
        public int Next() =>
            random.Next();

        public int Next(int max) =>
            random.Next(max);
    }
}
