namespace Minesweeper.Data.Player
{
    using System;
    using Minesweeper.Helpers;
    using Minesweeper.Interfaces;

    /// <summary>
    /// Implements the proxy design pattern. Used to set and check the validity of the used details.
    /// </summary>
    [Serializable]
    public class PlayerProxy : IPlayer
    {
        private IPlayer player;

        /// <summary>
        /// Constructor for the class ProxyPlayer.
        /// </summary>
        /// <param name="nickname">Input string for the player's nickname.</param>
        /// <param name="score">>Input integeer for the player's score.</param>
        public PlayerProxy(string nickname, int score)
        {
            this.player = new Player();
            this.Nickname = nickname;
            this.Score = score;
        }

        /// <summary>
        /// Get and Set nickname of the player and validate it.
        /// </summary>
        public string Nickname
        {
            get
            {
                return this.player.Nickname;
            }

            set
            {
                Validator.ValidateStringLength(value, 2, 10, "Player nickname");
                this.player.Nickname = value;
            }
        }

        /// <summary>
        /// Get and Set score of the player and validate it.
        /// </summary>
        public int Score
        {
            get
            {
                return this.player.Score;
            }

            set
            {
                Validator.ValidateNonNegativeInt(value);
                this.player.Score = value;
            }
        }
    }
}
