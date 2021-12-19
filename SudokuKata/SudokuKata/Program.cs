using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuKata
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.Play();

            Console.WriteLine();
            Console.Write("Press ENTER to exit... ");
            Console.ReadLine();
        }
    }
}