namespace Minesweeper.Commands
{
    using Minesweeper.Data;
    using Minesweeper.Data.Player;
    using Minesweeper.Logic.Draw;
    using System;

    /// <summary>
    /// Deals with the EXIT command, inherits the Command abstract class
    /// </summary>
    public class ExitCommand : Command
    {
        /// <summary>
        /// Command for exiting the game environment.
        /// </summary>
        /// <param name="matrix">Object with the field and field logic</param>
        /// <param name="player">Current player.</param>
        /// <param name="printer">Printer for the game used currently</param>
        public ExitCommand(Matrix matrix, Player player, Printer printer)
            : base(matrix, player, printer)
        {
        }

        /// <summary>
        /// Method for execution the EXIT Command, which prints message to the console and exits the application
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
