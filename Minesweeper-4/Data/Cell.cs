namespace Minesweeper.Data
{
    using Minesweeper.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
