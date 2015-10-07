namespace Minesweeper.Menu
{
    using System;
    using Minesweeper.Engine;

    public class Navigation
    {
        private static int currentChoice = 0;

        public static void MainMenuNavigation(Enum e, MinesweeperEngine game)
        {

            currentChoice = MenuOrientation.VerticalOrientation(game, e);
            ///process input
            ProcessInput.ProcessMainMenu(currentChoice, game);
        }

        internal static void ReturnExitNavigation(MinesweeperEngine game, Enum e)
        {
           currentChoice = MenuOrientation.HorizontalOfMenus(game, e);

            ProcessInput.ProcessSecondMenu(currentChoice, game);
        }

        internal static void GameDifficultyNavigation(MinesweeperEngine game, Enum e)
        {
            currentChoice = MenuOrientation.VerticalOrientation(game, e);

            ProcessInput.ProcessGameDifficulty(currentChoice, game);
        }

        internal static void GameModeNavigation(MinesweeperEngine game, Enum e)
        {
            currentChoice = MenuOrientation.VerticalOrientation(game, e);

            ProcessInput.ProcessGameMode(currentChoice, game);
        }
    }
}
