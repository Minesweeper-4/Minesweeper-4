namespace Minesweeper.Commands
{
    using System;
    using Minesweeper.Data;
    using Minesweeper.Data.Player;
    using Minesweeper.Engine;
    using Minesweeper.Logic.Draw;

    /// <summary>
    /// Class that inherits the basic Command class, and deals with building the different types of matrices
    /// </summary>
    public class StartCommand : Command
    {
        private MatrixBuilder builder;
        private MatrixDirector director;
        private MinesweeperEngine engine;

        public StartCommand(MinesweeperEngine engine, Matrix matrix, Player player, MatrixDirector matrixDirector, MatrixBuilder matrixBuilder, Printer printer)
            : base(matrix, player, printer)
        {
            this.engine = engine;
            this.director = matrixDirector;
            this.builder = matrixBuilder;
        }

        /// <summary>
        /// Method that takes the chose option from the menu and invokes the method for creating the matrix
        /// </summary>
        /// <param name="commandInfo">START Command Neeeed</param>
        public override void Execute(ICommandInfo commandInfo)
        {
            string matrixSize = commandInfo.Params[0];
            if (matrixSize == "small")
            {
                this.engine.CreateMatrix(MatrixTypes.SMALL);
            }
            else if (matrixSize == "medium")
            {
                this.engine.CreateMatrix(MatrixTypes.MEDIUM);
            }
            else if (matrixSize == "big")
            {
                this.engine.CreateMatrix(MatrixTypes.BIG);
            }
            else
            {
                throw new Exception("Invalid matrix size");
            }
        }
    }
}
