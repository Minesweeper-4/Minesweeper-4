namespace Minesweeper.Interfaces
{
    public interface ICell
    {
        bool IsOpen { get; }
        bool IsBoomb { get; }
        char CurrentSymbol { get; }
    }
}
