namespace Minesweeper
{
    /// <summary>
    /// Score object class
    /// </summary>
    public class ScoreRecord
    {
        private string personName;
        private int scorePoints;

        /// <summary>
        /// Empty constructor needed for the serializer
        /// </summary>
        public ScoreRecord()
        {
        }

        /// <summary>
        /// Instantiate Scorerecord class
        /// </summary>
        /// <param name="personName">Player name</param>
        /// <param name="points">Points</param>
        public ScoreRecord(string personName, int points)
        {
            this.personName = personName;
            this.scorePoints = points;
        }

        /// <summary>
        /// Gets and sets Person name property
        /// </summary>
        public string PersonName
        {
            get
            {
                return this.personName;
            }

            set
            {
                this.personName = value;
            }
        }

        /// <summary>
        /// gets and sets Score points
        /// </summary>
        public int ScorePoints
        {
            get
            {
                return this.scorePoints;
            }

            set
            {
                this.scorePoints = value;
            }
        }
    }
}
