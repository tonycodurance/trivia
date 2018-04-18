using System;
using NUnit.Framework;
using Trivia;

namespace TriviaTests
{
    [TestFixture]
    public class PlayersShould
    {
        private Players _players;
        private Player _firstPlayer;
        private Player _secondPlayer;
        private Player _thirdPlayer;
        
        [SetUp]
        public void Init()
        {
            _players = new Players();
            
            var firstPlayerName = Guid.NewGuid().ToString();
            var secondPlayerName = Guid.NewGuid().ToString();
            var thirdPlayerName = Guid.NewGuid().ToString();
            _firstPlayer = new Player(firstPlayerName);
            _secondPlayer = new Player(secondPlayerName);
            _thirdPlayer = new Player(thirdPlayerName);
        }

        [Test]
        public void Have_no_players()
        {
            var players = new Players();
            Assert.That(players.Count, Is.EqualTo(0));
        }

        [Test]
        public void Add_a_player()
        {
           _players.Add(_firstPlayer);
            
            Assert.That(_players.Count, Is.EqualTo(1));
            Assert.That(_players[0], Is.EqualTo(_firstPlayer));
        }

        [Test]
        public void Add_many_players()
        {
            _players.Add(_firstPlayer);
            _players.Add(_secondPlayer);
            _players.Add(_thirdPlayer);
            
            Assert.That(_players.Count, Is.EqualTo(3));
            Assert.That(_players[0], Is.EqualTo(_firstPlayer));
            Assert.That(_players[1], Is.EqualTo(_secondPlayer));
            Assert.That(_players[2], Is.EqualTo(_thirdPlayer));
        }

        [Test]
        public void Set_current_player_to_first_player()
        {
            _players.Add(_firstPlayer);
            _players.Add(_secondPlayer);
            
            Assert.That(_players.CurrentPlayerIndex, Is.EqualTo(0));
        }
        
        [Test]
        public void GetNextPlayer()
        {
            _players.Add(_firstPlayer);
            _players.Add(_secondPlayer);

            var actualPlayer = _players.GetNextPlayer();
            
            Assert.That(actualPlayer, Is.EqualTo(1));
            Assert.That(_players.CurrentPlayerIndex, Is.EqualTo(1));
        }
        
        [Test]
        public void GetNextPlayerWhenReachingTheEndOfPlayersList()
        {
            _players.Add(_firstPlayer);
            _players.Add(_secondPlayer);
            
            _players.GetNextPlayer();
            
            var actualPlayerIndex = _players.GetNextPlayer();
            
            Assert.That(actualPlayerIndex, Is.EqualTo(0));
            Assert.That(_players.CurrentPlayerIndex, Is.EqualTo(0));
        }
    }
}