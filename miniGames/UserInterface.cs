using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniGames
{
    public class UserInterface
    {
                public void Start()
        {
            Console.Clear();
            CoinGame coinToss = new();
            DiceGame diceToss = new();
            Console.WriteLine("What do you want to do?\n");
            Console.WriteLine("1. Throw dice!");
            Console.WriteLine("2. Flip coins!");
            System.Console.WriteLine("3. exit");

            if (int.TryParse(Console.ReadLine(), out int input))
            {
                switch (input)
                {
                    case 1:
                        diceToss.InitializePlayers();
                        break;
                    case 2:
                        coinToss.InitializePlayers();
                        break;
                    case 3:
                        ExitProgram();
                        break;
                    default:
                        Console.WriteLine("wrong input");
                        Console.ReadLine();
                        Start();
                        break;
                }
            }
            else
            {
                Console.WriteLine("wrong input");
                Console.ReadLine();
                Start();
            }
        }
        public static void ExitProgram()
        {
            Console.WriteLine("The program will close!");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}