namespace Minesweeper.Helpers
{
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    /// <summary>
    /// Sets a serializer, used for storing the current state of the game, and retrieving it afterwards
    /// </summary>
    public class Serializer
    {
        /// <summary>
        /// An empty constructor for the Serializer.
        /// </summary>
        public Serializer()
        {
        }

        /// <summary>
        /// Serialize given object in file by given file name. If the file doesn't exist it will be created.
        /// </summary>
        /// <param name="memento">Input object for serializing.</param>
        /// <param name="fileName">Input file name as string.</param>
        public void Serialize(object memento, string fileName)
        {
            if (!File.Exists(fileName))
            {
                var myFile = File.Create(fileName);
                myFile.Close();
            }

            var writer = new FileStream(fileName, FileMode.Open);

            BinaryFormatter mySerializer = new BinaryFormatter();

            mySerializer.Serialize(writer, memento);
            writer.Position = 0;

            writer.Close();
        }

        /// <summary>
        /// Deserialize object from file by given file name.
        /// </summary>
        /// <param name="fileName">Input file name as string.</param>
        /// <returns>Returns a deserialized object.</returns>
        public object Deserialize(string fileName)
        {
            var writer = new FileStream(fileName, FileMode.Open);

            BinaryFormatter mySerializer = new BinaryFormatter();

            var memento = mySerializer.Deserialize(writer);

            writer.Close();

            return memento;
        }
    }
}
