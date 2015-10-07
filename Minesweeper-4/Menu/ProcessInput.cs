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
            switch (currentChoice)
            {
                case 0:
                    game.ExecuteCommand("start small");
                    break;
                case 1:
                    game.ExecuteCommand("start medium");
                    break;
                case 2:
                    game.ExecuteCommand("start big");
                    break;
            }
        }

        public static void ProcessGameMode(int currentChoice, MinesweeperEngine game)
        {
            switch (currentChoice)
            {
                case 0:
                    game.ExecuteCommand("mode light");
                    break;
                case 1:
                    game.ExecuteCommand("mode dark");
                    break;
            }
            Navigation.ReturnExitNavigation(game, new SecondMenuOptions());
        }

        public static void ProcessMainMenu(int inputChoice, MinesweeperEngine game)
        {
            if (inputChoice == 0)
            {
                Console.Clear();
                PrintLogo.Print();
                Console.SetCursorPosition((CustomizeConsole.Width / 2) - 10, 10);
                Console.WriteLine("- CHOOSE GAME DIFFICULTY -\n");

                Navigation.GameDifficultyNavigation(game, new MatrixTypes());

            }
            else if (inputChoice == 1)
            {
                Console.Clear();
                PrintLogo.Print();
                Console.SetCursorPosition((CustomizeConsole.Width / 2) - 10, 10);
                Console.WriteLine("- HIGH SCORES -\n");
                game.ExecuteCommand("highscore");
                Navigation.ReturnExitNavigation(game, new SecondMenuOptions());
            }
            else if (inputChoice == 2)
            {
                Console.Clear();
                PrintLogo.Print();
                Console.SetCursorPosition((CustomizeConsole.Width / 2) - 10, 10);
                Console.WriteLine("- CHOOSE MODE TO PLAY -\n\n");

                Navigation.GameModeNavigation(game, new ModeOptions());

                Navigation.ReturnExitNavigation(game, new SecondMenuOptions());
            }
            else if (inputChoice == 3)
            {
                Console.Clear();
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