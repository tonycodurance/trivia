namespace Trivia
{
    public class Player
    {
        private readonly string _playerName;

        public Player(string playerName)
        {
            _playerName = playerName;
            Coins = 0;
        }

        public int Coins { get; private set; }

        public void AddCoin()
        {
            Coins++;
        }
    }
}