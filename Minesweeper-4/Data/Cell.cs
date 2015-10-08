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

        public Cell()
        {
            this.isOpen = false;
            this.IsBomb = false;
        }

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
