namespace Minesweeper.Menu
{
    using Engine;
    using System;

    public class MainMenu
    {
       internal static void PrintMenu(MinesweeperEngine game)
        {
            Console.Clear();
            PrintLogo.Print();
            Console.WriteLine("\n\n");
            int indexForPrint = (CustomizeConsole.Width / 2) - ("MAIN MENU:".Length / 2);
            Console.SetCursorPosition(indexForPrint, 9);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("MAIN MENU:");

            Console.ForegroundColor = ConsoleColor.Green;

            Navigation.MainMenuNavigation(new MainMenuOptions(), game);
        }
    }
}
