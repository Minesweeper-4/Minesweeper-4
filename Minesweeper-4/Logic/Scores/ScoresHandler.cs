namespace Minesweeper.Logic.Scores
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Interfaces;
    using Minesweeper.Helpers;
    using Minesweeper.Logic.Sorter;

    /// <summary>
    /// Inherits the IScoreHandle interfaces, and implements some addition check for the record file. Save, Sort and Load records
    /// </summary>
    public class ScoresHandler : IScoresHandler
    {
        private List<IPlayer> records;
        private SortStrategy sortStrategy = new DefaultSort();
        private Serializer serializer = new Serializer();

        /// <summary>
        /// Instantiate ScoresHandler class
        /// </summary>
        public ScoresHandler()
        {
            this.records = new List<IPlayer>();
        }

        /// <summary>
        /// Gets player reccords
        /// </summary>
        public IList<IPlayer> Reccords
        {
            get { return this.records; }
        }

        /// <summary>
        /// Add records to player
        /// </summary>
        /// <param name="player">Input player</param>
        public void AddReccord(IPlayer player)
        {
            int lastRecordScore = 0;

            if (this.Reccords.Count != 0) 
            {
                lastRecordScore = this.records.Last().Score;
            }

            if (this.records.Count < 10 || player.Score > lastRecordScore)
            {
                this.records.Add(player);
            }

            this.SortRecords();
        }

        /// <summary>
        /// Save records to file
        /// </summary>
        /// <param name="filePath">File path</param>
        public void SaveToFile(string filePath)
        {
            this.serializer.Serialize(this.records, filePath);
        }

        /// <summary>
        /// Load records form file
        /// </summary>
        /// <param name="filePath">File path</param>
        public void LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                var myFile = File.Create(filePath);
                myFile.Close();
            }

            var fileInfo = new FileInfo(filePath);

            if (fileInfo.Length == 0)
            {
                this.records = new List<IPlayer>();
            }
            else
            {
                var records = this.serializer.Deserialize(filePath) as List<IPlayer>;
                this.records = records.ToList<IPlayer>();
            }
        }

        private void SortRecords()
        {
            this.records = this.sortStrategy.Sort(this.records);
        }
    }
}