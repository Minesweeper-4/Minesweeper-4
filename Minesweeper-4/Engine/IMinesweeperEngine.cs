namespace Minesweeper.Engine
{
    public interface IMinesweeperEngine
    {
        void Start();
        void ExecuteCommand(string command);
        void CreateMatrix(MatrixTypes type);
    }
}