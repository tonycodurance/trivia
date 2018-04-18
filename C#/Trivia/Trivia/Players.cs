using System.Collections.Generic;

namespace Trivia
{
    public class Players
    {
        private readonly List<Player> _players;
        public int CurrentPlayerIndex { get; private set; }
        public int Count => _players.Count;

        public Players()
        {
            CurrentPlayerIndex = 0;
            _players = new List<Player>();
        }
        
        public Player this[int playerIndex] => _players[playerIndex];

        public void Add(Player player)
        {
            _players.Add(player);
        }

        public int GetNextPlayer()
        {
            CurrentPlayerIndex = (CurrentPlayerIndex + 1) % _players.Count;
            return CurrentPlayerIndex;
        }
    }
}