namespace Minesweeper.Data
{
    public abstract class MatrixBuilder
    {
        protected Matrix matrix;

        public MatrixBuilder()
        {
            this.Matrix = new Matrix();
        }

        public Matrix Matrix
        {
            get
            {
                return this.matrix;
            }

            private set
            {
                this.matrix = value;
            }
        }

        public abstract void SetField();
        public abstract void InitCells();
        public abstract void SetBombs();
        public abstract void SetNumberOfMines();

        public Matrix GetMatrix()
        {
            return this.Matrix;
        }
    }
}
