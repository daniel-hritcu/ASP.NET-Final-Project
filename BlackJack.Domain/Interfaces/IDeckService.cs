using BlackJack.Domain.PlayingCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Domain.Interfaces
{
    public interface IDeckService
    {

        /// <summary>
        /// Sets up the Deck as a standard playing cards deck.
        /// </summary>
        void Setup();

        /// <summary>
        /// Provides the 'shuffle' functionality for our deck of cards.
        /// </summary>
        void Shuffle();

        /// <summary>
        /// Provides the 'draw' functionality for our deck of cards.
        /// </summary>
        /// <returns>
        /// Returns the 'drawn card'.
        /// </returns>
        Card Draw();

        /// <summary>
        /// Draws a number of cards.
        /// </summary>
        /// <param name="count">
        /// The number of cards to be drawn.
        /// </param>
        /// <returns>
        /// List of cards drawn.
        /// </returns>
        List<Card> Draw(int count);
    }
}
