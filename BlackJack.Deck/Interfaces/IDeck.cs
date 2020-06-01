using System.Collections.Generic;
using BlackJack.Domain.PlayingCard;

namespace BlackJack.StandardDeck.Interfaces
{
    internal interface IStandardDeck
    {
        List<Card> Cards { get; set; }

        /// <summary>
        /// Generates a new deck and shuffles it.
        /// </summary>
        void Setup();
    }
}
