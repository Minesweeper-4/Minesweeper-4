namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Minesweeper.Engine;
    using System.Threading.Tasks;
    using System.Threading;
    using System.IO;
    using Menu;

    public class MinesweeperMain
    {
       
        static void Main()
        {
            CustomizeConsole.Customize();
            PrintLogo.Print();

            MainMenu.PrintMenu();

            // Demonstrating thread-safe implementation
            //Parallel.For(0, 23, x => MinesweeperEngine.Instance.PrintThreadNumber(x));

        }
    }
}
