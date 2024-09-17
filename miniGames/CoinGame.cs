using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniGames
{
    public class CoinGame
    {
        private UserInterface ui = new();
        private string? playerOne;
        private string? playerTwo;
        private List<int> tails = new();
        private List<int> heads = new();
        private Random randomNum = new();
        private int coinFlips = 1;
        private int coinTurns = 1;
        private int roundsPlayed = 1;
        private int headsWin = 0;
        private int tailsWin = 0;
        private int ties = 0;
        private bool running = true;
        public void Menu()
        {
            try
            {
                Console.Clear();
                while (running)
                {
                    System.Console.WriteLine("Type 1. to toss a dice several times 2. for just one time 3. to reset 4. to change players 5. to go back to the menu 6. to close program:");
                    int x = Int32.Parse(Console.ReadLine()!);

                    switch (x)
                    {
                        case 1:
                            SeveralTurns();
                            break;
                        case 2:
                            SingleTurn();
                            break;
                        case 3:
                            ClearAll();
                            break;
                        case 4:
                            NewPlayers();
                            break;
                        case 5:
                            ui.Start();
                            break;
                        case 6:
                            ExitProgram();
                            break;
                        default:
                            Console.WriteLine("wrong input");
                            Console.ReadLine();
                            Menu();
                            break;
                    }
                }
            }
            catch
            {
                System.Console.WriteLine("Only numbers as input!");
                Console.ReadLine();
                Menu();
            }
        }
        public void ExitProgram()
        {
            running = false;
            Console.Clear();
            Console.WriteLine("The program will close!");
            Console.ReadLine();
            Environment.Exit(0);
        }
        public void InitializePlayers()
        {
            Console.Clear();
            System.Console.WriteLine("Enter name of player one: ");
            playerOne = Console.ReadLine()!;
            System.Console.WriteLine("Enter name of player two: ");
            playerTwo = Console.ReadLine()!;
            Menu();
        }
        public void SingleTurn()
        {
            while (coinFlips <= 100)
            {
                int coin = randomNum.Next(2) + 1;
                if (coin == 1)
                {
                    heads.Add(coinFlips);
                }
                else
                {
                    tails.Add(coinFlips);
                }
                coinFlips++;
            }
            Count();
            roundsPlayed++;
        }
        public void SeveralTurns()
        {
            Console.WriteLine("How many turns do you want to play?");
            if (int.TryParse(Console.ReadLine(), out int turns))
            {
                while (coinTurns <= turns)
                {
                    SingleTurn();
                    coinTurns++;
                }
                coinTurns = 1;
            }
        }
        private void Count()
        {
            Console.Clear();
            GameInitialize();
            GameResults();
            Statistics();
            FinalResult();
            coinFlips = 1;
            tails.Clear();
            heads.Clear();
        }
        private void GameInitialize()
        {
            Console.WriteLine("** COIN TOSS **");
            Console.WriteLine($"Heads: {heads.Count} : Tails: {tails.Count}");
            Console.WriteLine("************");
            Console.WriteLine($"Heads: {heads.Count}\nHeads count: {string.Join(", ", heads)}");
            Console.WriteLine("***********");
            Console.WriteLine($"Tails: {tails.Count}\nTails count: {string.Join(", ", tails)}\n");
        }
        private void GameResults()
        {
            if (heads.Count > tails.Count)
            {
                Console.WriteLine($"{playerOne} is the winner!");
                headsWin++;
            }
            else if (heads.Count == tails.Count)
            {
                ties++;
                Console.WriteLine("Tied!");
            }
            else
            {
                Console.WriteLine($"{playerTwo} is the winner!");
                tailsWin++;
            }
        }
        private void Statistics()
        {
            Console.WriteLine("\n*******");
            double total = headsWin + tailsWin + ties;
            Console.WriteLine($"Rounds played: {roundsPlayed}");
            Console.WriteLine($"\nTimes {playerOne} have won: {headsWin}   Percentage: {(headsWin / total) * 100:0.00} %");
            Console.WriteLine($"Times {playerTwo} have won: {tailsWin}   Percentage: {(tailsWin / total) * 100:0.00} %");
            Console.WriteLine($"Tied rounds: {ties}      Percentage: {(ties / total) * 100:0.00} %");
        }
        private void FinalResult()
        {
            if (headsWin > tailsWin)
            {
                Console.WriteLine($"\n{playerOne} won with: {headsWin - tailsWin} more won rounds! \n");
            }
            else if (headsWin == tailsWin)
            {
                Console.WriteLine("\nIt's a tie!");
            }
            else
            {
                Console.WriteLine($"\n{playerTwo} won with: {tailsWin - headsWin} more won rounds! \n");
            }
        }
        public void ClearAll()
        {
            headsWin = 0;
            tailsWin = 0;
            ties = 0;
            roundsPlayed = 1;
            coinTurns = 1;
            Console.Clear();
        }
        public void NewPlayers()
        {
            ClearAll();
            InitializePlayers();
        }
    }
}