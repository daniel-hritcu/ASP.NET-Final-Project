using BlackJack.Domain.GameLogic;
using BlackJack.Domain.PlayingCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Domain.Interfaces
{
    public interface IBlackJackGameService
    {
        /// <summary>
        /// Lock in bet and deal first cards
        /// </summary>
        GameState Deal(double bet);

        /// <summary>
        /// Give player 1 card
        /// </summary>
        GameState Hit();

        /// <summary>
        /// Player will not recive any more cards. 
        /// EndGame will be executed.
        /// </summary>
        GameState Stand();
    }
}
