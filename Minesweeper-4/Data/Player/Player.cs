namespace Minesweeper.Data.Player
{
    using System;
    using System.Xml.Serialization;
    using Minesweeper.Interfaces;

    /// <summary>
    /// Set the details of the player
    /// </summary>
    [Serializable]
    public class Player : IPlayer
    {
        private int score;
        private string nickname;

        /// <summary>
        /// An Empty constructor for the Player class.Empty constructor is required for Serializing.
        /// </summary>
        public Player()
        {
        }

        /// <summary>
        /// Constructor for the Player class.
        /// </summary>
        /// <param name="nickName">Input string for the player's nickname.</param>
        /// <param name="scores">Input integeer for the player's score.</param>
        public Player(string nickName, int scores)
        {
            this.Nickname = nickName;
            this.Score = scores;
        }

        /// <summary>
        /// Get and Set nickname of the player.
        /// </summary>
        public string Nickname
        {
            get
            {
                return this.nickname;
            }

            set
            {
                this.nickname = value;
            }
        }

        /// <summary>
        /// Get and Set score of the player.
        /// </summary>
        public int Score
        {
            get
            {
                return this.score;
            }

            set
            {
                this.score = value;
            }
        }
    }
}
