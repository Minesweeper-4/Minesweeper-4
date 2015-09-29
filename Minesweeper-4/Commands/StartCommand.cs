namespace Minesweeper.Commands
{
    using Minesweeper.Data;
    using Minesweeper.Data.Player;
    using Minesweeper.Logic.Draw;

    public class StartCommand : Command
    {
        public StartCommand(Matrix matrix, Player player, MatrixDirector matrixDirector, MatrixBuilder matrixBuilder, Printer printer)
            : base(matrix, player, matrixDirector, matrixBuilder, printer)
        {
        }


        public override void Execute(ICommandInfo commandInfo)
        {
            base.director.Construct(builder);
            base.matrix = builder.GetMatrix();
            base.printer.PrintMatrix(matrix, player);
        }
    }
}
