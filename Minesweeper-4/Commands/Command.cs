namespace Minesweeper.Commands
{
    using Minesweeper.Data;
    using Minesweeper.Data.Player;
    using Minesweeper.Logic.Draw;

    /// <summary>
    /// Abstract class to be used as a basis for implementation of the different console commands. Factory Pattern used
    /// </summary>
    public abstract class Command
    {
        private Printer printer;
        private Matrix matrix;
        private Player player;

        /// <summary>
        /// Sets the obligatory parameters needed to process the commands in the constuctor
        /// </summary>
        /// <param name="matrix">import the matrix</param>
        /// <param name="player">set the current player</param>
        /// <param name="printer">import the printer</param>
        public Command(Matrix matrix, Player player, Printer printer)
        {
            this.Matrix = matrix;
            this.Player = player;
            this.Printer = printer;
        }

        public Printer Printer
        {
            get
            {
                return this.printer;
            }

            set
            {
                this.printer = value;
            }
        }

        public Matrix Matrix
        {
            get
            {
                return this.matrix;
            }

            set
            {
                this.matrix = value;
            }
        }

        public Player Player
        {
            get
            {
                return this.player;
            }

            set
            {
                this.player = value;
            }
        }

        /// <summary>
        /// Method for the execution of the command
        /// </summary>
        /// <param name="commandInfo">take the command as argument and implement the logic</param>
        public abstract void Execute(ICommandInfo commandInfo);
    }
}
