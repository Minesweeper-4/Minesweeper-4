namespace Minesweeper.Interfaces
{
    /// <summary>
    /// Set the obligatory properties needed for setting storing a result of a player
    /// </summary>
    public interface IPlayer
    {
        string Nickname { get; set; }

        int Score { get; set; } 
    }
}
