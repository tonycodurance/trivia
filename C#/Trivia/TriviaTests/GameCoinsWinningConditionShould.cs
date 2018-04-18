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
        public void IdentifyWinningCondition(int numberOfPlayerCoins, bool expectedPlayerIsWinner)
        {
            var gameConditions = new GameCoinsWinningCondition();
//            var player = new Player();
//            for (var i = 0; i < numberOfCorrectAnswers; i++)
//            {
//                player.AddCoin();
//            }

            var actualPlayerIsWinner = gameConditions.CurrentPlayerWinner(numberOfPlayerCoins);

            Assert.That(actualPlayerIsWinner, Is.EqualTo(expectedPlayerIsWinner));
        }
    }
}