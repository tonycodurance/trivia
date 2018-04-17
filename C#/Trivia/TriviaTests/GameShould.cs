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
        [TestCase(Three, Rock)]
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
            var game = new Game();

            var categoryForPlayer = Game.GiveCategoryFor(playerLocation);
            
            Assert.That(expectedCategory, Is.EqualTo(categoryForPlayer));
        }
    }
}