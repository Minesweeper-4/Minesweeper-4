namespace Minesweeper.Data
{
    /// <summary>
    /// The base class used for implementing the matrixsize, fields, bombs and mines.
    /// </summary>
    public abstract class MatrixBuilder
    {
        private Matrix matrix;

        /// <summary>
        /// Empty constructor for the MatrixBuilder class. Initialize a new Matrix.
        /// </summary>
        public MatrixBuilder()
        {
            this.Matrix = new Matrix();
        }

        /// <summary>
        /// Return the matrix instance.
        /// </summary>
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

        /// <summary>
        /// Initialize the Field of the Matrix.
        /// </summary>
        public abstract void SetField();

        /// <summary>
        /// Initialize every cell of the Filed of the Matrix.
        /// </summary>
        public abstract void InitCells();

        /// <summary>
        /// Set bombs in the Matrix Field.
        /// </summary>
        public abstract void SetBombs();

        /// <summary>
        /// Set the number of surrounded mines for each cell.
        /// </summary>
        public abstract void SetNumberOfMines();

        /// <summary>
        /// Return the matrix instance. 
        /// </summary>
        /// <returns></returns>
        public Matrix GetMatrix()
        {
            return this.Matrix;
        }
    }
}
