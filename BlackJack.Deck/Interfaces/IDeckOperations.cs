using BlackJack.Domain.PlayingCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.StandardDeck.Interfaces
{
    internal interface IDeckOperations
    {
        /// <summary>
        /// Shuffles the cards in the deck.
        /// </summary>
        void Shuffle();

        /// <summary>
        /// Draws a card from the deck
        /// </summary>
        /// <returns>
        /// One Card
        /// </returns>
        Card Draw();

        /// <summary>
        /// Draws multiple cards from the deck
        /// </summary>
        /// <param name="count">
        /// The number of cards to be drawn
        /// </param>
        /// <returns>
        /// A list of cards drawn.
        /// </returns>
        List<Card> Draw(int count);
    }
}
