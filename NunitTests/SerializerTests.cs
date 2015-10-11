namespace NunitTests
{
    using System;
    using System.IO;
    using Minesweeper.Helpers;
    using NUnit.Framework;

    /// <summary>
    /// Test Ran on file creation
    /// </summary>
    [TestFixture]
    public class SerializerTests
    {
        /// <summary>
        /// Expects to create a file, if the file does not exists
        /// </summary>
        [Test]
        public void ExpectSerializeMethodToCreateFileIfTheFileDoesntExist()
        {
            var fileName = "testFile.txt";
            object testObjectToSerialize = new object();
            var serializer = new Serializer();

            serializer.Serialize(testObjectToSerialize, fileName);

            Assert.True(File.Exists(fileName));
            File.Delete(fileName);
        }

        /// <summary>
        /// Expects to return the object when the file exists
        /// </summary>
        [Test]
        public void ExpectDeserializeMethodToReturnObjectWhenFileExist()
        {
            var fileName = "testFile.txt";
            var testObjectToSerialize = new object();
            var serializer = new Serializer();

            serializer.Serialize(testObjectToSerialize, fileName);

            var deserializedObject = serializer.Deserialize(fileName);

            Assert.NotNull(deserializedObject);

            File.Delete(fileName);
        }
    }
}
