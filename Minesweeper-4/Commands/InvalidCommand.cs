namespace Minesweeper.Commands
{
    using Minesweeper.Data;
    using Minesweeper.Data.Player;
    using Minesweeper.Engine;
    using Minesweeper.Logic.Draw;

    public class InvalidCommand : Command
    {
        public InvalidCommand(Matrix matrix, Player player, Printer printer)
            : base(matrix, player, printer)
        {
        }

        public override void Execute(ICommandInfo commandInfo)
        {
            base.printer.PrintLine("Invalid command!");
        }
    }
}