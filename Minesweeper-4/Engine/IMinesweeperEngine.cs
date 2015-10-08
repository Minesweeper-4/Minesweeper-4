namespace Minesweeper.Engine
{
    /// <summary>
    /// Set the obligatory properties, needed for execution of the matrix application
    /// </summary>
    public interface IMinesweeperEngine
    {
        void Start();

        void ExecuteCommand(string command);

        void CreateMatrix(MatrixTypes type);
    }
}