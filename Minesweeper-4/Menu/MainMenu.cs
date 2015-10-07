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
            Console.WriteLine("MAIN MENU:");

            Navigation.MainMenuNavigation(new MainMenuOptions(), game);
        }
    }
}
