namespace Minesweeper.Commands
{
    using System;
    using Minesweeper.Data;
    using Minesweeper.Data.Player;
    using Minesweeper.Engine;
    using Minesweeper.Logic.Draw;

    /// <summary>
    /// Deals with the EXIT command, inherits the Command abstract class
    /// </summary>
    public class ExitCommand : Command
    {
        public ExitCommand(Matrix matrix, Player player, Printer printer)
            : base(matrix, player, printer)
        {
        }

        /// <summary>
        /// Metrhod for execution the EXIT Command, which prints message to the console and exits the application
        /// </summary>
        /// <param name="commandInfo">EXIT Commmad needed as an argument</param>
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
