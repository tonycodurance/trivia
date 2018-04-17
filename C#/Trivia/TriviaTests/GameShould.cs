using System;
using System.Collections.Generic;
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

        [TestCase(Pop)]
        [TestCase(Sports)]
        [TestCase(Science)]
        [TestCase(Rock)]
        public void AskQuestionForGivenCategory(Category category)
        {
            var game = new Game();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Console.SetError(stringWriter);
            var questions = new LinkedList<string>();
            questions.AddLast("expectedQuestion");
            
            game.AskQuestion(category, new Dictionary<Category, LinkedList<string>>
            {
                {category, questions},
            });
            var actualQuestion = stringWriter.ToString();

            Assert.That(actualQuestion, Is.EqualTo("expectedQuestion\n"));
        }
    }

}