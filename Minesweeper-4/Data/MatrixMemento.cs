namespace Minesweeper.Data
{
    using Minesweeper.Interfaces;

    public class MatrixMemento
    {
        private ICell[,] field;

        public MatrixMemento()
        {

        }

        public MatrixMemento(ICell[,] field)
        {
            this.Field = field;
        }

        public ICell[,] Field
        {
            get
            {
                return this.field;
            }

            set
            {
                this.field = value;
            }
        }
    }
}
