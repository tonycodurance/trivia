using System;
using NUnit.Framework;
using Trivia;

namespace TriviaTests
{
    [TestFixture]
    public class PlayersShould
    {
        [Test]
        public void Have_no_players()
        {
            var players = new Players();
            Assert.That(players.Count, Is.EqualTo(0));
        }

        [Test]
        public void Add_a_player()
        {
            var player = Guid.NewGuid().ToString();
            var players = new Players();

            players.Add(player);
            
            Assert.That(players.Count, Is.EqualTo(1));
            Assert.That(players[0], Is.EqualTo(player));
        }
        
        [Test]
        public void Add_many_players()
        {
            var firstPlayer = Guid.NewGuid().ToString();
            var secondPlayer = Guid.NewGuid().ToString();
            var thirdPlayer = Guid.NewGuid().ToString();
            
            var players = new Players();

            players.Add(firstPlayer);
            players.Add(secondPlayer);
            players.Add(thirdPlayer);
            
            Assert.That(players.Count, Is.EqualTo(3));
            Assert.That(players[0], Is.EqualTo(firstPlayer));
            Assert.That(players[1], Is.EqualTo(secondPlayer));
            Assert.That(players[2], Is.EqualTo(thirdPlayer));
        }
        
        [Test]
        public void Set_current_player_to_first_player()
        {
            var firstPlayer = Guid.NewGuid().ToString();
            var secondPlayer = Guid.NewGuid().ToString();
            var players = new Players();
            players.Add(firstPlayer);
            players.Add(secondPlayer);
            
            Assert.That(players.CurrentPlayerIndex, Is.EqualTo(0));
        }
        
        [Test]
        public void Advance_current_player_to_second_player()
        {
            var firstPlayer = Guid.NewGuid().ToString();
            var secondPlayer = Guid.NewGuid().ToString();
            var players = new Players();
            players.Add(firstPlayer);
            players.Add(secondPlayer);

            players.SetToNextPlayer();
            
            Assert.That(players.CurrentPlayerIndex, Is.EqualTo(1));
        }
        
        [Test]
        public void Advance_current_player_back_to_first_player()
        {
            var firstPlayer = Guid.NewGuid().ToString();
            var secondPlayer = Guid.NewGuid().ToString();
            var players = new Players();
            players.Add(firstPlayer);
            players.Add(secondPlayer);
            players.SetToNextPlayer();
            
            players.SetToNextPlayer();
            
            Assert.That(players.CurrentPlayerIndex, Is.EqualTo(0));
        }
    }
}