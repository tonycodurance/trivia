using static Trivia.WinningConditions;

namespace Trivia
{
    public class GameCoinsWinningCondition
    {
        private WinningConditions _numberOfCoinsToWin = WinningCoins;

        public bool CurrentPlayerWinner(int playerCoins)
        {
            return playerCoins == (int)_numberOfCoinsToWin;
        }
    }
    
    public enum WinningConditions
    {
        WinningCoins = 6
    }
}