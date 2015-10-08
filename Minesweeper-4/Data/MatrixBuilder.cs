namespace Minesweeper.Data
{
    /// <summary>
    /// The base class used for implementing the matrixsize, fields, bombs and mines.
    /// </summary>
    public abstract class MatrixBuilder
    {
        private Matrix matrix;

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
