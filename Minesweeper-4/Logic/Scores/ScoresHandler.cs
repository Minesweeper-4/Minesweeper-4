namespace Minesweeper.Logic.Scores
{
    using Minesweeper.Data.Player;
    using Minesweeper.Helpers;
    using Interfaces;
    using Minesweeper.Logic.Sorter;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    public class ScoresHandler : IScoresHandler
    {
        private List<IPlayer> records;
        private SortStrategy sortStrategy = new DefaultSort();
        private Serializer serializer = new Serializer();

        public ScoresHandler()
        {
            this.records = new List<IPlayer>();
        }

        public IList<IPlayer> Reccords
        {
            get { return this.records; } // changed for making it testable. Was NotImplemented
        }

        public void AddReccord(IPlayer player)
        {
            int lastRecordScore = 0;

            if (this.Reccords.Count != 0) // added to make the method testable
            {
                lastRecordScore = this.records.Last().Score;
            }

            if (this.records.Count < 10 || player.Score > lastRecordScore)
            {
                this.records.Add(player);
            }

            SortRecords();
        }

        public void SaveToFile(string filePath)
        {
            this.serializer.Serialize(this.records, filePath);
        }

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