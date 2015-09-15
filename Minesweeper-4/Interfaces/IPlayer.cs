namespace Minesweeper.Interfaces
{
    interface IPlayer
    {
        string NickName { get; set; }

        int Scores { get; set; } 
    }
}
