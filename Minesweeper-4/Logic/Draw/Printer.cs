namespace Minesweeper.Logic.Draw
{
    using Minesweeper.Interfaces;

    /// <summary>
    /// Sets the obligatory properties for printing the matrix on the console
    /// </summary>
    public abstract class Printer
    {
        /// <summary>
        /// Method which prints a given string.
        /// </summary>
        /// <param name="message">String message.</param>
        public abstract void PrintLine(string message);

        /// <summary>
        /// Method which prints the matrix.
        /// </summary>
        /// <param name="matrix">Current matrix.</param>
        /// <param name="player">Current player.</param>
        public abstract void PrintMatrix(IMatrix matrix, IPlayer player);

        /// <summary>
        /// Prints the matrix with player info.
        /// </summary>
        /// <param name="matrix">Current matrix.</param>
        /// <param name="player">Current player.</param>
        /// <returns></returns>
        public abstract string GetPrintFrame(IMatrix matrix, IPlayer player);
    }
}
