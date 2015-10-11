namespace NunitTests
{
    using Minesweeper.Data.Player;
    using NUnit.Framework;

    /// <summary>
    /// Tests ran on player's empty constructor
    /// </summary>
    [TestFixture]
    public class PlayerClassEmptyConstructorTest
    {
        /// <summary>
        /// Checks whether the empty constructor constructs an instance
        /// </summary>
        [Test]
        public void PlayerClassEmptyConstructorMustConstructInstance()
        {
            Player player = new Player();

            Assert.IsInstanceOf(typeof(Player), player, "Memento instance doesn't exist");
        }
    }
}