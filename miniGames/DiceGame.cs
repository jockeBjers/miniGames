using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniGames
{
    public class DiceGame
    {
           private string? playerOne;
        private string? playerTwo;
        private bool running = true;
        private UserInterface ui = new();
        private int playerOnePoints = 0;
        private int playerTwoPoints = 0;
        Random rand = new();
        public void Menu()
        {
          
            while (running)
            {
                System.Console.WriteLine("Press 1. to Start the game. 2. to go back to main menu, or 3. Exit.");
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    switch (input)
                    {
                        case 1:
                            DiceRoll();
                            break;
                        case 2:
                            ui.Start();
                            break;
                        case 3:
                           ExitProgram();
                            break;
                        default:
                            Console.WriteLine("wrong input");
                            Console.ReadLine();
                            Menu();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("wrong input");
                    Console.ReadLine();
                    DiceRoll();
                }
            }
        }
        public void ExitProgram()
        {
            running = false;
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

        public void DiceRoll()
        {
            InitializeGame();
            DiceLogic();
            Results();
        }
        public void InitializeGame()
        {
            Console.Clear();
            Console.WriteLine("Dice Game");
            Console.WriteLine();
            Console.WriteLine("In this game you will play 10 rounds");
            Console.WriteLine("You get points each round by getting a pair.");
            Console.WriteLine("who wins the most rounds wins the game");
            Console.WriteLine();
            Console.Write("Press any key to start");
            Console.ReadLine();
        }
        public void DiceLogic()
        {
            Console.Clear();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Round {i + 1}");
                int dieOne = rand.Next(1, 7);
                int dieTwo = rand.Next(1, 7);
                Console.WriteLine($"{playerOne} rolled a {dieOne} and a {dieTwo}");
                if (dieOne == dieTwo)
                {
                    playerOnePoints++;
                    Console.WriteLine($"{playerOne} Got a point with a matching pair!");
                }
                dieOne = Random.Shared.Next(1, 7);
                dieTwo = Random.Shared.Next(1, 7);
                Console.WriteLine($"{playerTwo} rolled a {dieOne} and a {dieTwo}");
                if (dieOne == dieTwo)
                {
                    playerTwoPoints++;
                    Console.WriteLine($"{playerTwo} Got a point with a matching pair!");
                }
                Console.WriteLine($"Current score: {playerOne}: {playerOnePoints} | {playerTwo}: {playerTwoPoints}");
                Console.Write("Press any key to continue...");
                Console.ReadLine();
                Console.WriteLine();
            }
        }
        public void Results()
        {
            Console.Clear();
            Console.WriteLine("GAME OVER.");
            Console.WriteLine($"The end score is:  {playerOne}: {playerOnePoints} | {playerTwo}: {playerTwoPoints}");
            if (playerOnePoints > playerTwoPoints)
            {
                Console.WriteLine(playerOne + " won!");
            }
            else if (playerOnePoints < playerTwoPoints)
            {
                Console.WriteLine(playerTwo + " won!");
            }
            else
            {
                Console.WriteLine("This game is a draw.");
            }
            Console.Write("Press to continue...");
            Console.ReadLine();
            Console.Clear();
        }

    }
}