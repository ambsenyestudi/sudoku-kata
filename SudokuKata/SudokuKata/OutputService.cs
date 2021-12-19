using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
