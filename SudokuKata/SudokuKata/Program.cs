using System;

namespace SudokuKata
{
    class Program
    {
        static void Main(string[] args)
        {
            var outputService = new OutputService();
            var game = new Game(outputService);
            game.Play();

            Console.WriteLine();
            Console.Write("Press ENTER to exit... ");
            Console.ReadLine();
        }
    }
}