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
        /// <returns>
        /// GameState object with player information
        /// and the state of the game
        /// </returns>
        GameState Deal(double bet);

        /// <summary>
        /// Give player 1 card
        /// </summary>
        /// <returns>
        /// GameState object with player information
        /// and the state of the game
        /// </returns>
        GameState Hit();

        /// <summary>
        /// Player will not recive any more cards. 
        /// EndGame will be executed.
        /// </summary>
        /// <returns>
        /// GameState object with player information
        /// and the state of the game
        /// </returns>
        GameState Stand();

        /// <summary>
        /// Init a new game
        /// </summary>
        /// <returns>
        /// GameState object with player information
        /// and the state of the game
        /// </returns>
        GameState NewGame();
    }
}
