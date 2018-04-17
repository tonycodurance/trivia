using System;
using System.Collections.Generic;
using System.Linq;
using static Trivia.Category;

namespace Trivia
{
    public class GameQuestions
    {
        private readonly Dictionary<Category, LinkedList<string>> _questionsForCategory;

        public GameQuestions(Dictionary<Category, LinkedList<string>> questionsForCategory)
        {
            _questionsForCategory = questionsForCategory;
        }
        
        public GameQuestions()
        {
            var popQuestions = new LinkedList<string>();
            var scienceQuestions = new LinkedList<string>();
            var sportsQuestions = new LinkedList<string>();
            var rockQuestions = new LinkedList<string>();
            var geographyQuestions = new LinkedList<string>();
            for (var i = 0; i < 50; i++)
            {
                popQuestions.AddLast("Pop Question " + i);
                scienceQuestions.AddLast(("Science Question " + i));
                sportsQuestions.AddLast(("Sports Question " + i));
                rockQuestions.AddLast("Rock Question " + i);
                geographyQuestions.AddLast("Geography Question " + i);
            }

            _questionsForCategory = new Dictionary<Category, LinkedList<string>>
            {
                {Pop, popQuestions},
                {Science, scienceQuestions},
                {Sports, sportsQuestions},
                {Rock, rockQuestions},
                {Geography, geographyQuestions}
            };
        }
       
        public void AskQuestion(Category category)
        {
            Console.WriteLine(_questionsForCategory[category].First());
            _questionsForCategory[category].RemoveFirst();
        }
    }
}