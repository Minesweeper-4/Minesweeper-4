using Minesweeper.Engine;
using System;

namespace Minesweeper.Menu
{
    internal class ProcessInput
    {
        public static void ProcessSecondMenu(int currentChoice, MinesweeperEngine game)
        {
            switch (currentChoice)
            {
                case 0:
                    Console.Clear();
                    PrintLogo.Print();
                    MainMenu.PrintMenu(game);
                    break;
                case 1:
                    game.ExecuteCommand("exit");
                    break;
            }
        }

        public static void ProcessGameDifficulty(int currentChoice, MinesweeperEngine game)
        {
            Console.ForegroundColor = ConsoleColor.White;
            switch (currentChoice)
            {
                case 0:
                    game.ExecuteCommand("start");
                    break;
                case 1:
                    game.ExecuteCommand("start");
                    break;
                case 2:
                    game.ExecuteCommand("start");
                    break;
            }
        }

        public static void ProcessMainMenu(int inputChoice, MinesweeperEngine game)
        {
            if (inputChoice == 0)
            {
                Console.Clear();
                PrintLogo.Print();
                Console.SetCursorPosition((CustomizeConsole.Width / 2) - 10, 10);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("- CHOOSE GAME DIFFICULTY -\n");

                Navigation.GameDifficultyNavigation(game, new MatrixTypes());

            }
            else if (inputChoice == 1)
            {
                Console.Clear();
                PrintLogo.Print();
                Console.SetCursorPosition((CustomizeConsole.Width / 2) - 10, 10);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("- HIGH SCORES -\n");
                game.ExecuteCommand("highscore");
                Navigation.ReturnExitNavigation(game, new SecondMenuOptions());
            }
            else if (inputChoice == 2)
            {
                Console.Clear();
                PrintLogo.Print();
                Console.SetCursorPosition((CustomizeConsole.Width / 2) - 10, 10);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("- CHOOSE MODE TO PLAY -\n\n");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\t\t\t\tLIGHT\n");
                Console.WriteLine("\t\t\t\tDARK");

                Navigation.ReturnExitNavigation(game, new SecondMenuOptions());
            }
            else if (inputChoice == 3)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                PrintLogo.Print();
                Console.SetCursorPosition(20, 9);
                Console.WriteLine(" - HOW TO PLAY - ");

                Navigation.ReturnExitNavigation(game, new SecondMenuOptions());
            }
            else if (inputChoice == 4)
            {
                game.ExecuteCommand("exit");
            }
        }
    }
}