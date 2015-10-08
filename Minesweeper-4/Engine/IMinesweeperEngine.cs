namespace Minesweeper.Engine
{
    /// <summary>
    /// Set the obligatory properties, needed for execution of the matrix application
    /// </summary>
    public interface IMinesweeperEngine
    {
        /// <summary>
        /// Method which builds game and sets game fields.
        /// </summary>
        void Start();

        /// <summary>
        /// Method which process input commands
        /// </summary>
        /// <param name="command">inut command</param>
        void ExecuteCommand(string command);

        /// <summary>
        /// Method for creating the game matrix.
        /// </summary>
        /// <param name="type">Matrix type</param>
        void CreateMatrix(MatrixTypes type);
    }
}