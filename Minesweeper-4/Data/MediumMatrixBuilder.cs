namespace Minesweeper.Data
{
    /// <summary>
    /// Inherits the base Matrix builder class, and implement the logic for building medium size matrix
    /// </summary>
    public class MediumMatrixBuilder : MatrixBuilder
    {
        /// <summary>
        /// Initialize the Field of the Matrix.
        /// </summary>
        public override void SetField()
        {
            this.Matrix.Field = new Cell[10, 10];
        }

        /// <summary>
        /// Initialize every cell of the Filed of the Matrix.
        /// </summary>
        public override void InitCells()
        {
            for (int i = 0; i < this.Matrix.Field.GetLongLength(0); i++)
            {
                for (int j = 0; j < this.Matrix.Field.GetLongLength(1); j++)
                {
                    var currentCell = new Cell();
                    this.Matrix.Field[i, j] = currentCell;
                }
            }
        }

        /// <summary>
        /// Set bombs in the Matrix Field.
        /// </summary>
        public override void SetBombs()
        {
            this.Matrix.SetBombs(10);
        }

        /// <summary>
        /// Set the number of surrounded mines for each cell.
        /// </summary>
        public override void SetNumberOfMines()
        {
            this.Matrix.SetNumberOfMines();
        }
    }
}
