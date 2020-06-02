using BlackJack.Domain.GameLogic;
using BlackJack.Domain.Interfaces;
using BlackJack.Game.Game;

namespace BlackJack.Game.Services
{
    public partial class BlackJackGameService : IBlackJackGameService
    {
        private GameLogic _gameLogic;

        public BlackJackGameService()
        {
            //Init GameLogic
            _gameLogic = new GameLogic();
        }

        public GameState NewGame() 
        {
            return _gameLogic.NewGame();
        }

        public GameState Deal(double bet)
        {
            return _gameLogic.Deal(bet);
        }

        public GameState Hit()
        {
            return _gameLogic.Hit();
        }

        public GameState Stand()
        {
            return _gameLogic.Stand();
        }
    }
}
