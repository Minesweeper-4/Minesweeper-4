﻿namespace Minesweeper.Logic.Scores
{
    using Minesweeper.Data.Player;
    using Minesweeper.Logic.Sorter;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    public class ScoresHandler : IScoresHandler
    {
        private List<Player> records;
        private string storingPath;
        private SortStrategy sortStrategy = new DefaultSort();

        public ScoresHandler(string storingPath)
        {
            this.StoringPath = storingPath;
            this.records = new List<Player>();
        }

        public IList<Player> Reccords
        {
            get { return this.records; } // changed for making it testable. Was NotImplemented
        }

        public string StoringPath
        {
            get
            {
                return this.storingPath;
            }

            private set
            {
                if (string.IsNullOrEmpty(value)) // validation added
                {
                    throw new ArgumentNullException("The storing path is null or empty string");
                }

                this.storingPath = value;
            }
        }

        public void AddReccord(Player player)
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

        public void SaveToFile()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Player>));

            using (StreamWriter streamWriter = System.IO.File.CreateText(this.StoringPath))
            {
                xmlSerializer.Serialize(streamWriter, this.records);
            }
        }

        public void LoadFromFile()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Player>));

            using (StreamReader streamReader = new System.IO.StreamReader(this.StoringPath))
            {
                this.records = xmlSerializer.Deserialize(streamReader) as List<Player>;
            }
        }

        private void SortRecords()
        {
            this.records = this.sortStrategy.Sort(this.records);
        }
    }
}