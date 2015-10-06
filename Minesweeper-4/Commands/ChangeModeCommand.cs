namespace Minesweeper.Commands
{
    using Minesweeper.Data;
    using Minesweeper.Data.Player;
    using Minesweeper.Engine;
    using Minesweeper.Logic.Draw;

    public class ChangeModeCommand : Command
    {
        public ChangeModeCommand(Matrix matrix, Player player, Printer printer)
            : base(matrix, player, printer)
        {
        }

        public override void Execute(ICommandInfo commandInfo)
        {
            var printerLightMode = new PrinterLightMode();
            printerLightMode.SetPrinter(this.printer);
            printerLightMode.Apply();
            printerLightMode.PrintMatrix(this.matrix, this.player);
            this.printer = printerLightMode;
        }
    }
}
