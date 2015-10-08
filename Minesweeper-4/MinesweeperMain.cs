namespace Minesweeper
{
    using Menu;
    using Minesweeper.Engine;

    public class MinesweeperMain
    {
        public static void Main()
        {
            CustomizeConsole.Customize();
            PrintLogo.Print();

            var game = MinesweeperEngine.Instance;
            MainMenu.PrintMenu(game);

            /// Demonstrating thread-safe implementation
            /// Parallel.For(0, 23, x => MinesweeperEngine.Instance.PrintThreadNumber(x));
        }
    }
}
