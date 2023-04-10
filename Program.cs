using System;
namespace MinesweeperGame
{
    class Program
    {
        public static void Main(string[] args) 
        {
            Game game = new Game();
            game.ClearMap();
            game.SetMine();
            int x;
            char y;

            while (game.state == State.GameNotFinished)
            {
                game.PrintMap();
                Console.WriteLine("Enter letter: ");
                y = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine("\nEnter number: ");
                x = int.Parse(Console.ReadLine());

                if (game.CheckLose(x, y))
                {
                    Console.WriteLine("You lost!");
                    break;
                }
                else
                {
                    continue;
                }
                if (game.CheckWin())
                {
                    Console.WriteLine("You won!");
                    break;
                }
            }

            
            Console.ReadKey();
        }
    }
    }


