namespace Minesweeper.Commands
{
    using Minesweeper.Data;
    using Minesweeper.Data.Player;
    using Minesweeper.Engine;
    using Minesweeper.Logic.Draw;
    using Menu;

    public class ChangeModeCommand : Command
    {
        private MinesweeperEngine engine;

        public ChangeModeCommand(MinesweeperEngine engine, Matrix matrix, Player player, Printer printer)
            : base(matrix, player, printer)
        {
            this.engine = engine;
        }

        public override void Execute(ICommandInfo commandInfo)
        {
            if (commandInfo.Params[0] == "light")
            {
                var printerLightMode = new PrinterLightMode();
                printerLightMode.SetPrinter(this.printer);
                printerLightMode.Apply();
            }
            else if (commandInfo.Params[0] == "dark")
            {
                var printerDarkMode = new PrinterDarkMode();
                printerDarkMode.SetPrinter(this.printer);
                printerDarkMode.Apply();
            }
            Navigation.ReturnExitNavigation(engine, new SecondMenuOptions());
        }
    }
}
