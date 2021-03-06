﻿namespace Minesweeper.Menu
{
    using Minesweeper.Engine;
    using System;

    /// <summary>
    /// Class for navigating betweens the different menus
    /// </summary>
    public class Navigation
    {
        private static int currentChoice = 0;

        /// <summary>
        /// Process the request for the MAIN MENU from the navigation to the class that will retrieve it
        /// </summary>
        /// /// <param name="game">Import the game engine</param>
        /// <param name="e">Takes the desired enumeration for processing the navigation</param>
        public static void MainMenuNavigation(MinesweeperEngine game, Enum e)
        {
            currentChoice = MenuOrientation.VerticalOrientation(game, e);

            ProcessInput.ProcessMainMenu(currentChoice, game);
        }
        
        /// <summary>
        /// Process the request for the RETURN/EXIT MENU from the navigation to the class that will retrieve it
        /// </summary>
        /// <param name="game">Import the game engine</param>
        /// <param name="e">Takes the desired enumeration for processing the navigation</param>
        internal static void ReturnExitNavigation(MinesweeperEngine game, Enum e)
        {
           currentChoice = MenuOrientation.HorizontalOfMenus(game, e);

            ProcessInput.ProcessSecondMenu(currentChoice, game);
        }

        /// <summary>
        /// Process the request for GAMEDIFFICULTY MENU from the navigation to the class that will retrieve it
        /// </summary>
        /// <param name="game">Import the game engine</param>
        /// <param name="e">Takes the desired enumeration for processing the navigation</param>
        internal static void GameDifficultyNavigation(MinesweeperEngine game, Enum e)
        {
            currentChoice = MenuOrientation.VerticalOrientation(game, e);

            ProcessInput.ProcessGameDifficulty(currentChoice, game);
        }

        /// <summary>
        /// Process the request for LIGHT/DARK MODE MENU from the navigation to the class that will retrieve it
        /// </summary>
        /// <param name="game">Import the game engine</param>
        /// <param name="e">Takes the desired enumeration for processing the navigation</param>
        internal static void GameModeNavigation(MinesweeperEngine game, Enum e)
        {
            currentChoice = MenuOrientation.VerticalOrientation(game, e);

            ProcessInput.ProcessGameMode(currentChoice, game);
        }
    }
}
