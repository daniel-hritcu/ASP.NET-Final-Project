using BlackJack.StandardDeck.Exceptions;
using BlackJack.Domain.Interfaces;
using BlackJack.Domain.PlayingCard;
using System;
using System.Collections.Generic;

namespace BlackJack.StandardDeck.Services
{
    /// <summary>
    /// Provides access to a standard deck of cards and it's operation.
    /// </summary>
    ///<seealso cref = "Domain.Interfaces.IDeckService">
    /// Method description at the interface.
    ///</seealso>
    public class DeckService : IDeckService
    {
        private Deck _deck;
        
        public DeckService()
        {
            _deck = new Deck();
        }

        public void Setup()
        {
            _deck.Setup();
        }

        public void Shuffle()
        {
            _deck.DeckOperations.Shuffle();
        }

        public Card Draw()
        {
            return _deck.DeckOperations.Draw();
        }

        public List<Card> Draw(int count)
        {
            return _deck.DeckOperations.Draw(count);
        }
    }
}
