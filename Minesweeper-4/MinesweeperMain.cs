namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Minesweeper.Engine;
    using System.Threading.Tasks;

    public class MinesweeperMain
    {
        static void Main()
        {
            //var game = new MinesweeperEngine();

            var game = MinesweeperEngine.Instance;
            game.Start();

            // Demonstrating thread-safe implementation
            //Parallel.For(0, 23, x => MinesweeperEngine.Instance.PrintThreadNumber(x));
        }
    }
}
