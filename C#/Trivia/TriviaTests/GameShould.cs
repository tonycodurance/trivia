using System;
using System.IO;
using Moq;
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
            var categoryForPlayer = Game.GiveCategoryFor(playerLocation);
            
            Assert.That(categoryForPlayer, Is.EqualTo(expectedCategory));
        }

        [TestCase(Pop, "Pop Question 0\n")]
        [TestCase(Sports, "Sports Question 0\n")]
        [TestCase(Science, "Science Question 0\n")]
        [TestCase(Rock, "Rock Question 0\n")]
        public void AskQuestionForGivenCategory(Category category, string expectedQuestion)
        {
            var game = new TestGame(category);
            
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Console.SetError(stringWriter);
            
            game.AskQuestion();
            var actualQuestion = stringWriter.ToString();

            Assert.That(actualQuestion, Is.EqualTo(expectedQuestion));
        }
    }

    public class TestGame : Game
    {
        private readonly Category _category;

        public TestGame(Category category)
        {
            _category = category;
        }

        public override bool CurrentCategoryIs(Category category)
        {
            return _category == category;
        }
    }
}