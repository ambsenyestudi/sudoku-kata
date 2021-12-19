using System;

namespace SudokuKata
{
    class Program
    {
        static void Main(string[] args)
        {
            var randomService = new RandomService();
            var outputService = new OutputService();
            var game = new Game(randomService);
            var gameOutput = game.Play();
            foreach (var outputMessage in gameOutput)
            {
                outputService.Print(outputMessage);
            }
            
            Console.WriteLine();
            Console.Write("Press ENTER to exit... ");
            Console.ReadLine();
        }
    }
}
