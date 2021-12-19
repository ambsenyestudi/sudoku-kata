using SudokuKata.Domain.Boards;
using System;

namespace SudokuKata
{
    class Program
    {
        static void Main(string[] args)
        {
            var randomService = new RandomService();
            var outputService = new OutputService();
            var gameBoard = new Board();
            var game = new Game(gameBoard, outputService, randomService);
            game.Play();

            Console.WriteLine();
            Console.Write("Press ENTER to exit... ");
            Console.ReadLine();
        }
    }
}
