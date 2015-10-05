namespace Minesweeper.Commands
{
    using Minesweeper.Data;
    using Minesweeper.Data.Player;
    using Minesweeper.Engine;
    using Minesweeper.Logic.Draw;

    public class StartCommand : Command
    {
        private MinesweeperEngine engine;

        public StartCommand(MinesweeperEngine engine, Matrix matrix, Player player, MatrixDirector matrixDirector, MatrixBuilder matrixBuilder, Printer printer)
            : base(matrix, player, matrixDirector, matrixBuilder, printer)
        {
            this.engine = engine;
        }


        public override void Execute(ICommandInfo commandInfo)
        {
            //base.matrix = (Matrix)(new MatrixFactory().CreateMatrix(MatrixTypes.BIG));
            //base.printer.PrintMatrix(matrix, player);

            this.engine.CreateMatrix();
        }
    }
}
