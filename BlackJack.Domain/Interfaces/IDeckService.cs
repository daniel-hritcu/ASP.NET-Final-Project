﻿using BlackJack.Domain.PlayingCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Domain.Interfaces
{
    public interface IDeck
    {
        List<Card> Cards { get; set; }

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
        /// Counts the number of cards in the deck.
        /// </summary>
        /// <returns>
        /// Returns the deck card count.
        /// </returns>
        int CardCount();


    }
}