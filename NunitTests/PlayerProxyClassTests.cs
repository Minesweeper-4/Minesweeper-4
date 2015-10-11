namespace NunitTests
{
    using Minesweeper.Data.Player;
    using NUnit.Framework;

    /// <summary>
    /// Tests Ran on the players Proxy Class
    /// </summary>
    [TestFixture]
    public class PlayerProxyClassTests
    {
        /// <summary>
        /// Checks whether the proxy constructor and the properties get and set work properly
        /// </summary>
        [Test]
        public void PlayerProxyConstructorAndPropertriesGetterAndSetterWorksProper()
        {
            string expectedNickName = "Pesho";
            int expectedScore = 15;

            PlayerProxy proxy = new PlayerProxy(expectedNickName, expectedScore);

            Assert.AreEqual(expectedNickName, proxy.Nickname, "Expected and actual PlayerProxy Nickname are not equal");
            Assert.AreEqual(expectedScore, proxy.Score, "Expected and actual PlayerProxy Score are not equal");
        }
    }
}