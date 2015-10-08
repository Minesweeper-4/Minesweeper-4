namespace Minesweeper.Data
{
    using System;
    using Minesweeper.Interfaces;

    /// <summary>
    /// Inherits the ICell interface and sets the logic for the cell value
    /// </summary>
    [Serializable]
    public class Cell : ICell
    {
        private bool isOpen;
        private bool isBomb;
        private int numberOfMines;

        /// <summary>
        /// Constructor for the Cell class.
        /// </summary>
        public Cell()
        {
            this.isOpen = false;
            this.IsBomb = false;
        }

        /// <summary>
        /// Return if the Cell is open or not.
        /// </summary>
        public bool IsOpen
        {
            get
            {
                return this.isOpen;
            }

            set
            {
                this.isOpen = value;
            }
        }

        /// <summary>
        /// Return information if the Cell is bomb or not.
        /// </summary>
        public bool IsBomb
        {
            get
            {
                return this.isBomb;
            }

            set
            {
                this.isBomb = value;
            }
        }

        /// <summary>
        /// Return how many surrounded bombs there are around the Cell.
        /// </summary>
        public int NumberOfMines
        {
            get
            {
                return this.numberOfMines;
            }

            set
            {
                this.numberOfMines = value;
            }
        }
    }
}
