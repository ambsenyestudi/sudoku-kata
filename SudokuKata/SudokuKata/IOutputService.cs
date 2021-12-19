using System.Collections.Generic;

namespace SudokuKata
{
    public interface IOutputService
    {
        void Print(params string[] mesageLines);
    }
}