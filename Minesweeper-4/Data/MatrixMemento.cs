namespace Minesweeper.Data
{
    using Minesweeper.Interfaces;
    using System;

    /// <summary>
    /// Saves the current state, using Memento
    /// </summary>
    [Serializable]
    public class MatrixMemento
    {
        private ICell[,] field;

        /// <summary>
        /// Empty constructor for the MatrixMemento class. Empty constructor is required for Serializing.
        /// </summary>
        public MatrixMemento()
        {
        }

        /// <summary>
        /// Constructor for the MatrixMemento class. Take a two dimensional array.
        /// </summary>
        /// <param name="field">Two dimensional array of ICells.</param>
        public MatrixMemento(ICell[,] field)
        {
            this.Field = field;
        }

        /// <summary>
        /// Get and Set the Field.
        /// </summary>
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
