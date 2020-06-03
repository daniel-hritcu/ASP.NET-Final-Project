using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Domain.GameLogic
{
    public class GameState
    {
        public Player DefaultPlayer { get; set; }
        public Player Dealer { get; set; }
        public State CurrentState { get; set; }
        public string StateName { get => CurrentState.ToString(); }

        public GameState(Player defaultPlayer, Player dealer, State currentState = State.NewGame)
        {
            DefaultPlayer = defaultPlayer;
            Dealer = dealer;
            CurrentState = currentState;
        }

        public GameState()
        {
        }
    }
}
