using System.Collections.Generic;

namespace Trivia
{
    public class Players
    {
        private readonly List<string> _players;
        public int CurrentPlayerIndex { get; private set; }
        public int Count => _players.Count;

        public Players()
        {
            CurrentPlayerIndex = 0;
            _players = new List<string>();
        }
        
        public string this[int playerIndex] => _players[playerIndex];

        public void Add(string player)
        {
            _players.Add(player);
        }

        public void SetToNextPlayer()
        {
            CurrentPlayerIndex = (CurrentPlayerIndex + 1) % _players.Count;
        }
    }
}