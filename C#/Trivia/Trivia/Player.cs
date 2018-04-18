namespace Trivia
{
    public class Player
    {
        public readonly string Name;

        public Player(string name)
        {
            Name = name;
            Coins = 0;
        }

        public int Coins { get; private set; }

        public void AddCoin()
        {
            Coins++;
        }
    }
}