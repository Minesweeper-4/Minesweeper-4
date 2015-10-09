namespace Minesweeper
{
    using Menu;
    using Minesweeper.Engine;

    /// <summary>
    /// Entry point class
    /// </summary>
    public class MinesweeperMain
    {
        /// <summary>
        /// The Main entry point method
        /// </summary>
        public static void Main()
        {
            CustomizeConsole.Customize();
            PrintLogo.Print();

            var game = MinesweeperEngine.Instance;
            MainMenu.PrintMenu(game);
        }
    }
}
