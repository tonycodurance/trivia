using NUnit.Framework;
using Trivia;

namespace TriviaTests
{
    [TestFixture]
    public class GameCoinsWinningConditionShould
    {
        [TestCase(6, true)]
        [TestCase(5, false)]
        [TestCase(1, false)]
        public void IdentifyWinningCondition(int playerCoins, bool expectedPlayerIsWinner)
        {
            var gameConditions = new GameCoinsWinningCondition();

            var actualPlayerIsWinner = gameConditions.CurrentPlayerWinner(playerCoins);

            Assert.That(actualPlayerIsWinner, Is.EqualTo(expectedPlayerIsWinner));
        }
    }
}