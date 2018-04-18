namespace Trivia
{
    public class GameCoinsWinningCondition
    {
        private readonly int _numberOfCoinsToWinGame;

        public GameCoinsWinningCondition(int numberOfCoinsToWinGame)
        {
            _numberOfCoinsToWinGame = numberOfCoinsToWinGame;
        }

        public bool CurrentPlayerWinner(int playerCoins)
        {
            return playerCoins == _numberOfCoinsToWinGame;
        }
    }
}