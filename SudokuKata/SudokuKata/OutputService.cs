using System;

namespace SudokuKata
{
    public class OutputService : IOutputService
    {
        public void Print(params string[] mesageLines)
        {
            foreach (var message in mesageLines)
            {
                Console.WriteLine(message);
            }
        }
    }
}
