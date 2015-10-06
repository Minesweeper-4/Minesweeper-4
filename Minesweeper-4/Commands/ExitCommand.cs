namespace Minesweeper.Commands
{
    using Minesweeper.Data;
    using Minesweeper.Data.Player;
    using Minesweeper.Engine;
    using Minesweeper.Logic.Draw;
    using System;

    public class ExitCommand : Command
    {
        public ExitCommand(Matrix matrix, Player player, Printer printer)
            : base(matrix, player, printer)
        {
        }

        public override void Execute(ICommandInfo commandInfo)
        {
            Console.Clear();
            Console.WriteLine("Good Bye!");
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    Environment.Exit(1);
                }
            }
        }
    }
}
