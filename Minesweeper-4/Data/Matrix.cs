namespace Minesweeper.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Matrix
    {
        private int rows;
        private int cols;
        private Cell[,] field;

        public Matrix(int rows, int cols)
        {
            this.Field = new Cell[rows, cols];
        }

        public int Rows
        {
            get
            {
                return this.rows;
            }

            set
            {
                this.rows = value;
            }
        }

        public int Cols
        {
            get
            {
                return this.cols;
            }

            set
            {
                this.cols = value;
            }
        }

        public Cell[,] Field
        {
            get
            {
                return this.field;
            }

            private set
            {
                this.field = value;
            }
        }
    }
}
