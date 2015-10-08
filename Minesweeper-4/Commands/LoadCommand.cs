namespace Minesweeper.Commands
{
    using Minesweeper.Data;
    using Minesweeper.Data.Player;
    using Minesweeper.Helpers;
    using Minesweeper.Logic.Draw;

    /// <summary>
    /// Class that inherits the base Command Class and implements the loading of the previously saved game
    /// </summary>
    public class LoadCommand : Command
    {
        /// <summary>
        /// Constructor for the Load command
        /// </summary>
        /// <param name="matrix">Current game matrix</param>
        /// <param name="player">Current game player.</param>
        /// <param name="printer">Current game printer.</param>
        public LoadCommand(Matrix matrix, Player player, Printer printer)
            : base(matrix, player, printer)
        {
        }

        /// <summary>
        /// Method that uses initializes new serializer to takes the previously saved game
        /// </summary>
        /// <param name="commandInfo"></param>
        public override void Execute(ICommandInfo commandInfo)
        {
            var serializer = new Serializer();
            var memento = serializer.Deserialize(GlobalErrorMessages.SaveMatrixFileName) as MatrixMemento;

            this.Matrix.RestoreMemento(memento);
        }
    }
}