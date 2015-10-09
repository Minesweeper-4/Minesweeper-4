namespace Minesweeper.Menu
{
    using Engine;
    using System;
    using Minesweeper.Enumerations;

    /// <summary>
    /// Set the positioning and visibility of the Main Menu
    /// </summary>
    public class MainMenu
    {
        /// <summary>
        /// Takes the method for navigating through the main menu
        /// </summary>
        /// <param name="game">Import the game Engine to start the application</param>
       internal static void PrintMenu(MinesweeperEngine game)
        {
            Console.Clear();
            PrintLogo.Print();
            Console.WriteLine("\n\n");
            int indexForPrint = (CustomizeConsole.Width / 2) - ("MAIN MENU:".Length / 2);
            Console.SetCursorPosition(indexForPrint, 9);
            Console.WriteLine("MAIN MENU:");

            Navigation.MainMenuNavigation(game, new MainMenuOptions());
        }
    }
}
