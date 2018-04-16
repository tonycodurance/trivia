using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    public class GameRunner
    {
        public static void Main(String[] args)
        {
            var triviaGame = new TriviaGame();
            triviaGame.Execute();
        }
    }

}

