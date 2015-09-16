﻿namespace Minesweeper.Data
{
    public class MediumMatrixBuilder : MatrixBuilder
    {
        public override void SetField()
        {
            this.Matrix.Field = new Cell[10, 10];
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
            base.Matrix.SetNumberOfMines();
        }
    }
}