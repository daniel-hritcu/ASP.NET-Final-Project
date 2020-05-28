using BlackJack.Domain.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Domain.Interfaces
{
    public interface IBlackJackGameService
    {
        Player DefaultPlayer { get; set; }
        Player Dealer { get; set; }
        IDeckService DeckService { get; set; }
        GameState GameState { get; set; }

        /// <summary>
        /// Lock in bet and deal first cards
        /// </summary>
        void Deal(int bet);

        /// <summary>
        /// Give player 1 card
        /// </summary>
        void Hit();

        /// <summary>
        /// Player will not recive any more cards. EndGame will be executed.
        /// </summary>
        void Stand();

        /// <summary>
        /// Calculates the best player score while trying not to bust.
        /// </summary>
        void GetScore();

        /// <summary>
        /// Dealer logic
        /// </summary>
        /// <par>
        /// The dealer must then hit or stand according to these rules:
        /// 
        /// 1. The dealer must count an ace as 11 points, unless this causes the dealer to bust. Then the dealer must count the ace as 1 point. 
        /// 2. If the dealer has a total of 17 points or more, he must stand. 
        /// 3. If the dealer has a total of less than 17 points, he must hit. jg
        /// </par>
        void EndGame();


    }
}
