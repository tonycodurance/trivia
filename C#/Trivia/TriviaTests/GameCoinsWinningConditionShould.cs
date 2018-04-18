using NUnit.Framework;
using Trivia;

namespace TriviaTests
{
    [TestFixture]
    public class GameCoinsWinningConditionShould
    {
        [TestCase(7, 6, false)]
        [TestCase(6, 6, true)]
        [TestCase(5, 5, true)]
        [TestCase(1, 2, false)]
        public void IdentifyWinningCondition(int numberOfPlayerCoins, int numberOfCoinsToWin, bool expectedPlayerIsWinner)
        {
            var gameConditions = new GameCoinsWinningCondition(numberOfCoinsToWin);

            var actualPlayerIsWinner = gameConditions.CurrentPlayerWinner(numberOfPlayerCoins);

            Assert.That(actualPlayerIsWinner, Is.EqualTo(expectedPlayerIsWinner));
        }
    }
}