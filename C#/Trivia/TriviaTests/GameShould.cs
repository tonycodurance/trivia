using NUnit.Framework;
using Trivia;
using static Trivia.Category;
using static Trivia.Location;

namespace TriviaTests
{
    [TestFixture]
    public class GameShould
    {
        [TestCase(Zero, Pop)]
        [TestCase(One, Science)]
        [TestCase(Two, Sports)]
        [TestCase(Three, Geography)]
        [TestCase(Four, Pop)]
        [TestCase(Five, Science)]
        [TestCase(Six, Sports)]
        [TestCase(Seven, Rock)]
        [TestCase(Eight, Pop)]
        [TestCase(Nine, Science)]
        [TestCase(Ten, Sports)]
        [TestCase(Eleven, Rock)]
        public void GiveCategoryForGivenPlayerLocation(Location playerLocation, Category expectedCategory)
        {
            var categoryForPlayer = Game.GiveCategoryFor(playerLocation);

            Assert.That(categoryForPlayer, Is.EqualTo(expectedCategory));
        }

        [TestCase(WinningConditions.WinningCoins, 6, true)]
        [TestCase(WinningConditions.WinningCoins, 5, false)]
        [TestCase(WinningConditions.WinningCoins, 1, false)]
        public void IdentifyWinningCondition(WinningConditions numberOfCoinsToWin, int playerCoins, bool expectedPlayerIsWinner)
        {
            var game = new GameTest(playerCoins);

            var actualPlayerIsWinner = game.CurrentPlayerWinner((int)numberOfCoinsToWin);

            Assert.That(actualPlayerIsWinner, Is.EqualTo(expectedPlayerIsWinner));
        }
    }

    public class GameTest : Game
    {
        private readonly int _playerCoins;

        public GameTest(int playerCoins)
        {
            _playerCoins = playerCoins;
        }

        public override int GetCurrentPlayerCoins()
        {
            return _playerCoins;
        }
    }
}