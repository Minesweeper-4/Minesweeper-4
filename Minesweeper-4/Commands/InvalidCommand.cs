namespace Minesweeper.Commands
{
    using Minesweeper.Data;
    using Minesweeper.Data.Player;
    using Minesweeper.Engine;
    using Minesweeper.Logic.Draw;

    /// <summary>
    /// Class that inherits the base Command class and deals with the wrong commands
    /// </summary>
    public class InvalidCommand : Command
    {
        public InvalidCommand(Matrix matrix, Player player, Printer printer)
            : base(matrix, player, printer)
        {
        }

        public override void Execute(ICommandInfo commandInfo)
        {
            this.Printer.PrintLine("Invalid command!");
        }
    }
}