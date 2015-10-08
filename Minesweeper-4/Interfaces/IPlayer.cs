namespace Minesweeper.Interfaces
{
    /// <summary>
    /// Set the obligatory properties needed for setting storing a result of a player
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// Player nick name.
        /// </summary>
        string Nickname { get; set; }

        /// <summary>
        /// Player score.
        /// </summary>
        int Score { get; set; } 
    }
}
