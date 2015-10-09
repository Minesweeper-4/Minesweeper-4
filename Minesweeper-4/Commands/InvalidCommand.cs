namespace Minesweeper.Commands
{
    using Minesweeper.Data;
    using Minesweeper.Data.Player;
    using Minesweeper.Logic.Draw;

    /// <summary>
    /// Class that inherits the base Command class and deals with the wrong commands
    /// </summary>
    public class InvalidCommand : Command
    {
        /// <summary>
        /// Constructor for the invalid command.
        /// </summary>
        /// <param name="matrix">Current game matrix</param>
        /// <param name="player">Current game player.</param>
        /// <param name="printer">Current game printer.</param>
        public InvalidCommand(Matrix matrix, Player player, Printer printer)
            : base(matrix, player, printer)
        {
        }

        /// <summary>
        /// Method for executing the command.
        /// </summary>
        /// <param name="commandInfo">Object which holds command name and parameters if any.</param>
        public override void Execute(ICommandInfo commandInfo)
        {
            this.Printer.PrintLine("Invalid command!");
        }
    }
}