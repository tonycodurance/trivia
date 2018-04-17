using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using Trivia;
using static Trivia.Category;

namespace TriviaTests
{
    [TestFixture]
    public class GameQuestionsShould
    {
        [TestCase(Pop)]
        [TestCase(Sports)]
        [TestCase(Science)]
        [TestCase(Rock)]
        public void AskQuestionForGivenCategory(Category category)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Console.SetError(stringWriter);
            var questions = new LinkedList<string>();
            questions.AddLast("expectedQuestion");

            var gameQuestions = new GameQuestions(new Dictionary<Category, LinkedList<string>>
            {
                {category, questions},
            });
            gameQuestions.AskQuestion(category);
            var actualQuestion = stringWriter.ToString();

            Assert.That(actualQuestion, Is.EqualTo("expectedQuestion\n"));
        }

        [TestCase(Pop)]
        [TestCase(Science)]
        [TestCase(Sports)]
        [TestCase(Rock)]
        public void CreateAtLeast50SimplifiedQuestionsForEachCategory(Category category)
        {
            const int expectedNumberOfQuestions = 50;
            var gameQuestions = new GameQuestions();
            
            for (var i = 0; i < expectedNumberOfQuestions; i++)
            {
                var stringWriter = new StringWriter();
                Console.SetOut(stringWriter);
                Console.SetError(stringWriter);
                var expectedQuestion = category + " Question " + i + "\n";
                
                gameQuestions.AskQuestion(category);
                var question = stringWriter.ToString();
                
                Assert.That(question, Is.EqualTo(expectedQuestion));
            }
        }
    }
}