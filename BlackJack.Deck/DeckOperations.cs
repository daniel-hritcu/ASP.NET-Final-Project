using BlackJack.StandardDeck.Interfaces;
using BlackJack.Domain.PlayingCard;
using BlackJack.StandardDeck.Exceptions;
using System;
using System.Collections.Generic;

namespace BlackJack.StandardDeck
{
    /// <summary>
    /// Provides the basic operations of a standard deck of playing cards
    /// </summary>
    ///<seealso cref = "Interfaces.IDeckOperations">
    /// Method description at the interface.
    ///</seealso>
    ///
    public class DeckOperations : IDeckOperations
    {
        /// <summary>
        /// Provides the Random used in the Shuffle method.
        /// </summary>
        private static readonly Random Random = new Random();

        /// <summary>
        /// Sets the number of times the deck is shuffled.
        /// </summary>
        private const int shuffleTimes = 100;

        /// <summary>
        /// The list of cards in the deck.
        /// </summary>
        private List<Card> _deck { get; set; }

        public DeckOperations(List<Card> deck)
        {
            _deck = deck;
        }

        public void Shuffle()
        {
            int cardsCount = _deck.Count;

            //Shuffle the ammount of times defined in _shuffleTimes.
            for (int i = 0; i < shuffleTimes; i++)
            {
                while (cardsCount > 1)
                {
                    cardsCount--;

                    int index = Random.Next(cardsCount + 1);
                    Card card = _deck[index];
                    _deck[index] = _deck[cardsCount];
                    _deck[cardsCount] = card;
                }

            }
        }

        public Card Draw()
        {
            if (_deck.Count == 0)
            {
                throw new EmptyDeckException("Deck does not have any cards.");
            }

            //Select card
            Card drawnCard = _deck[0];

            //Remove from deck
            _deck.RemoveAt(0);

            //Return selected card
            return drawnCard;
        }

        public List<Card> Draw(int count)
        {
            //Init
            List<Card> drawnCardList = new List<Card>();

            //Draw the number of cards in count
            for (int i = 0; i < count; i++)
            {
                drawnCardList.Add(Draw());
            }

            //Return the list of drawn cards
            return drawnCardList;
        }
    }
}
