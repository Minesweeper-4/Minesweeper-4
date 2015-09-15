namespace Minesweeper.Interfaces
{
    public interface ICell
    {
        bool IsOpen { get; }
        bool IsBoomb { get; set; }
        char CurrentSymbol { get; set; }
    }
}
