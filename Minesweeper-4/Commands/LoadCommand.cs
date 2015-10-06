namespace Minesweeper.Commands
{
    using Minesweeper.Data;
    using Minesweeper.Data.Player;
    using Minesweeper.Engine;
    using Minesweeper.Logic.Draw;
    using Minesweeper.Helpers;

    public class LoadCommand : Command
    {
        public LoadCommand(Matrix matrix, Player player, Printer printer)
            : base(matrix, player, printer)
        {
        }

        public override void Execute(ICommandInfo commandInfo)
        {
            var serializer = new Serializer();
            var memento = serializer.Deserialize(GlobalErrorMessages.SaveMatrixFileName) as MatrixMemento;

            base.matrix.RestoreMemento(memento);
        }
    }
}