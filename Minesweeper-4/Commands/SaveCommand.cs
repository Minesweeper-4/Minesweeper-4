namespace Minesweeper.Commands
{
    using Minesweeper.Data;
    using Minesweeper.Data.Player;
    using Minesweeper.Helpers;
    using Minesweeper.Logic.Draw;

    /// <summary>
    /// Class that inherits the base Command class, and deals with saving the current state of the game, in order to be continued in the future
    /// </summary>
    public class SaveCommand : Command
    {
        /// <summary>
        /// Constructor for the Save command.
        /// </summary>
        /// <param name="matrix">Current game matrix.</param>
        /// <param name="player">Current game player</param>
        /// <param name="printer">Current game printer</param>
        public SaveCommand(Matrix matrix, Player player, Printer printer)
            : base(matrix, player, printer)
        {
        }

        /// <summary>
        /// Method for storing the state of the game. Uses memento pattern to execute the command
        /// </summary>
        /// <param name="commandInfo">SAVE Command needed</param>
        public override void Execute(ICommandInfo commandInfo)
        {
            var memento = this.Matrix.SaveMemento();
            var serializer = new Serializer();
            serializer.Serialize(memento, GlobalErrorMessages.SaveMatrixFileName);
        }
    }
}
