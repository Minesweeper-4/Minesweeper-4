namespace Minesweeper.Commands
{
    using Minesweeper.Data;
    using Minesweeper.Data.Player;
    using Minesweeper.Engine;
    using Minesweeper.Logic.Draw;
    using Minesweeper.Helpers;

    public class SaveCommand : Command
    {
        public SaveCommand(Matrix matrix, Player player, Printer printer)
            : base(matrix, player, printer)
        {
        }

        public override void Execute(ICommandInfo commandInfo)
        {
            var memento = this.matrix.SaveMemento();
            var serializer = new Serializer();
            serializer.Serialize(memento, GlobalErrorMessages.SaveMatrixFileName);
        }
    }
}
