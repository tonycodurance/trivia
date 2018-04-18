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
        [TestCase(Three, Geography)]
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

        [TestCase(6, true)]
        [TestCase(7, false)]
        [TestCase(100, false)]
        public void IdentifyWinningCondition(int playerCoins, bool expectedPlayerIsWinner)
        {
            var game = new GameTest(playerCoins);

            var actualPlayerIsWinner = game.CurrentPlayerWinner();
            
            Assert.That(actualPlayerIsWinner, Is.EqualTo(expectedPlayerIsWinner));
        }
    }
    
    public class GameTest : Game
    {
        private readonly int _playerCoins;

        public GameTest(int playerCoins)
        {
            _playerCoins = playerCoins;
        }

        public override int GetCurrentPlayerCoins()
        {
            return _playerCoins;
        }
    }
}