using Potempkin.src;
using System;

namespace Potempkin
{
    class Program
    {
        static void Main(string[] args)
        {
            // Does what it says on the tin
            // Correct
            // No proper error checks such as input validation and range checks but doesn't crash
            // Spartan UI
            // Extensible but not with constructor parameters
            // Compact codebase but plenty to talk about

            string Bomb;
            GameEngine game = new GameEngine();
            game.StartNewGame();
            Console.WriteLine("Greetings Professor Falken");
            Console.WriteLine("Shall we play a game?");
            Console.WriteLine();

            // Debug to generate random ships
            while (!true)
            {
                GameEngine game2 = new GameEngine();
                game2.StartNewGame();
                Console.WriteLine(game2.SpyLocations);
                Console.ReadKey();

            }

            while (!game.Lost)
            {
                // Console.WriteLine($"DEBUG: Squares occupied by enemy ships: {game.SpyLocations}");
                Console.WriteLine("Where do you want to fire?");
                Bomb = Console.ReadLine().ToUpper();  // VALIDATE INPUT
                game.FireShot(Bomb);
                Console.WriteLine($"{game.Status} ships still floating");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine($"Congratulations, you sunk the entire fleet in {game.NumberOfShots} shots!");
            Console.WriteLine("Please press any key to exit.");
            Console.ReadKey();            
        }
    }
}
