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
                Console.WriteLine("- CHOOSE GAME DIFFICULTY -\n\n\n");

                Navigation.GameDifficultyNavigation(game, new MatrixTypes());

            }
            else if (inputChoice == 1)
            {
                Console.Clear();
                PrintLogo.Print();
                Console.SetCursorPosition((CustomizeConsole.Width / 2) - 10, 10);
                Console.WriteLine("- HIGH SCORES -\n\n\n");
                game.ExecuteCommand("highscore");
                Navigation.ReturnExitNavigation(game, new SecondMenuOptions());
            }
            else if (inputChoice == 2)
            {
                Console.Clear();
                PrintLogo.Print();
                Console.SetCursorPosition((CustomizeConsole.Width / 2) - 10, 10);
                Console.WriteLine("- CHOOSE MODE TO PLAY -\n\n\n");

                Navigation.GameModeNavigation(game, new ModeOptions());

                Navigation.ReturnExitNavigation(game, new SecondMenuOptions());
            }
            else if (inputChoice == 3)
            {
                Console.Clear();
                PrintLogo.Print();
                Console.SetCursorPosition(20, 9);
                Console.WriteLine(" - HOW TO PLAY - \n\n\n");
                Console.WriteLine("   * Enter 'turn row col' (where row and col are numbers) to open a new field");
                Console.WriteLine("   * Enter 'exit' to Exit the game");
                Console.WriteLine("   * Enter 'save' to Save the current state of the game");
                Console.WriteLine("   * Enter 'load' to Load previously saved game");
                Console.WriteLine("   * Enter 'menu' to return to Main Menu");
                Console.WriteLine("   * Enter 'highscore' to review the highscores table");


                Navigation.ReturnExitNavigation(game, new SecondMenuOptions());
            }
            else if (inputChoice == 4)
            {
                game.ExecuteCommand("exit");
            }
        }
    }
}