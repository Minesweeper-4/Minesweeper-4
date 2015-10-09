namespace Minesweeper.Commands
{
    using Menu;
    using Minesweeper.Data;
    using Minesweeper.Data.Player;
    using Minesweeper.Engine;
    using Minesweeper.Enumerations;
    using Minesweeper.Logic.Draw;

    /// <summary>
    /// Inheritance and Expansion of the base class. Deals with the implementation of the switchign modes.
    /// </summary>
    public class ChangeModeCommand : Command
    {
        private MinesweeperEngine engine;

        /// <summary>
        /// Change the appearance of the game.
        /// </summary>
        /// <param name="engine">Game engine instantiated.</param>
        /// <param name="matrix">Game matrix used.</param>
        /// <param name="player">Current player for the game.</param>
        /// <param name="printer">Used printer for the game.</param>
        public ChangeModeCommand(MinesweeperEngine engine, Matrix matrix, Player player, Printer printer)
            : base(matrix, player, printer)
        {
            this.engine = engine;
        }

        /// <summary>
        /// Takes the "mode" command and process its implementation.
        /// </summary>
        /// <param name="commandInfo">Command used to switch from dark to light mode, and vise versa.</param>
        public override void Execute(ICommandInfo commandInfo)
        {
            if (commandInfo.Params[0] == "light")
            {
                var printerLightMode = new PrinterLightMode();
                printerLightMode.SetPrinter(this.Printer);
                printerLightMode.Apply();
            }
            else if (commandInfo.Params[0] == "dark")
            {
                var printerDarkMode = new PrinterDarkMode();
                printerDarkMode.SetPrinter(this.Printer);
                printerDarkMode.Apply();
            }

            Navigation.ReturnExitNavigation(this.engine, new SecondMenuOptions());
        }
    }
}
