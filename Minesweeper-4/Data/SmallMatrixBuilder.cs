namespace Minesweeper.Data
{
    using Minesweeper.Interfaces;

    /// <summary>
    /// Inherits the base Matrix builder class, and implement the logic for building small size matrix
    /// </summary>
    public class SmallMatrixBuilder : MatrixBuilder
    {
        public override void SetField()
        {
            this.Matrix.Field = new Cell[5, 5];
        }

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

        public override void SetBombs()
        {
            this.Matrix.SetBombs(10);
        }

        public override void SetNumberOfMines()
        {
            this.Matrix.SetNumberOfMines();
        }
    }
}
