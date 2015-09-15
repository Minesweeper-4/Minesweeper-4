namespace Minesweeper.Data
{
    using Minesweeper.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Cell : ICell
    {
        private bool isOpen;
        private bool isBoomb;
        private char currentSymbol;

        public Cell(char symbol)
        {
            this.CurrentSymbol = symbol;
            this.isOpen = false;
            this.IsBoomb = false;
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

        public bool IsBoomb
        {
            get
            {
                return this.isBoomb;
            }

            set
            {
                this.isBoomb = value;
            }
        }

        public char CurrentSymbol
        {
            get
            {
                return this.currentSymbol;
            }

            set
            {
                this.currentSymbol = value;
            }
        }
    }
}
