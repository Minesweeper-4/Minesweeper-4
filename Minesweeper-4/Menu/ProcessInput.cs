namespace Minesweeper.Menu
{
    using Minesweeper.Engine;
    using Minesweeper.Enumerations;
    using System;

    internal class ProcessInput
    {
        /// <summary>
        /// Process the set choice from RETURN/EXIT MENU and retrieves the result from it
        /// </summary>
        /// <param name="currentChoice">takes the set choice from the user as argument</param>
        /// <param name="game">imports the game engine</param>
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

        /// <summary>
        /// Process the set choice from GAMEDIFFICULTY MENU and retrieves the result from it
        /// </summary>
        /// <param name="currentChoice">takes the set choice from the user as argument</param>
        /// <param name="game">imports the game engine</param>
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

        /// <summary>
        /// Process the set choice from LIGHT/DARK MENU and retrieves the result from it
        /// </summary>
        /// <param name="currentChoice">takes the set choice from the user as argument</param>
        /// <param name="game">imports the game engine</param>
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

        /// <summary>
        /// Process the set choice from MAIN MENU and retrieves the result from it
        /// </summary>
        /// <param name="inputChoice">takes the set choice from the user as argument</param>
        /// <param name="game">imports the game engine</param>
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