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
            if (commandInfo.Params[0] == "light")
            {
                var printerLightMode = new PrinterLightMode();
                printerLightMode.SetPrinter(this.printer);
                printerLightMode.Apply();
                printerLightMode.PrintMatrix(this.matrix, this.player);
                this.printer = printerLightMode;
            }
            else if (commandInfo.Params[0] == "dark")
            {
                var printerDarkMode = new PrinterDarkMode();
                printerDarkMode.SetPrinter(this.printer);
                printerDarkMode.Apply();
                printerDarkMode.PrintMatrix(this.matrix, this.player);
                this.printer = printerDarkMode;
            }
        }
    }
}
