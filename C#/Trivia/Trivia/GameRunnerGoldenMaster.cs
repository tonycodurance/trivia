﻿using System;

namespace Trivia
{
    public class GameRunnerGoldenMaster
    {
        private static bool _notAWinner;

        public void Execute(int seed)
        {
            var aGame = new Game();

            aGame.add("Chet");
            aGame.add("Pat");
            aGame.add("Sue");

            var randomizer = new Random(seed);
            
            do
            {
                aGame.roll(randomizer.Next(5) + 1);

                if (randomizer.Next(9) == 7)
                {
                    _notAWinner = aGame.AnsweredIncorrectly();
                }
                else
                {
                    _notAWinner = aGame.AnsweredCorrectly();
                }
            } while (_notAWinner);
        }
    }
}