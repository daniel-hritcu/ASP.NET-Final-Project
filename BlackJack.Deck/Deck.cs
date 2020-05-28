using BlackJack.StandardDeck.Exceptions;
using BlackJack.Domain.Interfaces;
using BlackJack.Domain.PlayingCard;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BlackJack.StandardDeck
{
    /// <summary>
    /// Implements the functionality of a standard deck of playing cards
    /// </summary>
    ///<seealso cref = "Domain.Interfaces.IDeck">
    /// Method documentation at the interface.
    ///</seealso>
    public class Deck : IDeck
    {
        /// <summary>
        /// Provides the Random used in the Shuffle method.
        /// </summary>
        private static readonly Random Random = new Random();

        /// <summary>
        /// Sets the number of times the deck is shuffled.
        /// </summary>
        private const int _shuffleTimes = 100;

        public List<Card> Cards { get; set; }

        public Deck()
        {
            Setup();
        }

        
        public void Setup()
        {
            //Populate deck with cards
            Cards = new List<Card>(
                Enumerable.Range(1, 4)
                .SelectMany(suit => Enumerable.Range(2, 13)
                .Select(rank => new Card
                {
                    Suit = (CardSuit) suit,
                    Rank = (CardRank) rank
                })));

            //Shuffle the new deck
            Shuffle();
        }

        public void Shuffle()
        {
            int cardsCount = CardCount();

            //Shuffle the ammount of times defined in _shuffleTimes.
            for (int i = 0; i < _shuffleTimes; i++) {

                while (cardsCount > 1)
                {
                    cardsCount--;

                    int index = Random.Next(cardsCount + 1);
                    Card card = Cards[index];
                    Cards[index] = Cards[cardsCount];
                    Cards[cardsCount] = card;
                }

            }
        }

       
        public Card Draw()
        {
            if (CardCount() == 0)
            {
                throw new EmptyDeckException("Deck does not have any cards.");
            } 

            //Select card
            Card drawnCard = Cards[0];

            //Remove from deck
            Cards.RemoveAt(0);

            //Return selected card
            return drawnCard;
        }

        public int CardCount()
        {
            return Cards.Count;
        }
    }
}
