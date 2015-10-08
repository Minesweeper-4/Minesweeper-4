﻿namespace Minesweeper.Data
{
    using System;
    using Minesweeper.Interfaces;

    /// <summary>
    /// Saves the current state, using Memento
    /// </summary>
    [Serializable]
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
