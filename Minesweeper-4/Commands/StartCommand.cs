namespace Minesweeper.Commands
{
    using Minesweeper.Data;
    using Minesweeper.Data.Player;
    using Minesweeper.Engine;
    using Minesweeper.Logic.Draw;

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


        public override void Execute(ICommandInfo commandInfo)
        {
            //base.matrix = (Matrix)(new MatrixFactory().CreateMatrix(MatrixTypes.BIG));
            //base.printer.PrintMatrix(matrix, player);

            string matrixSize = commandInfo.Params[0];
            if (matrixSize == "small")
            {
                this.engine.CreateMatrix(MatrixTypes.SMALL);
            }
            else if(matrixSize == "medium")
            {
                this.engine.CreateMatrix(MatrixTypes.MEDIUM);
            }
            else if (matrixSize == "big")
            {
                this.engine.CreateMatrix(MatrixTypes.BIG);
            }
            else
            {
              //
            }
        }
    }
}
