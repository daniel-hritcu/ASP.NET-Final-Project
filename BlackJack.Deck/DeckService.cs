using BlackJack.StandardDeck.Exceptions;
using BlackJack.Domain.Interfaces;
using BlackJack.Domain.PlayingCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace BlackJack.StandardDeck
{
    /// <summary>
    /// Implements the functionality of a standard deck of playing cards
    /// </summary>
    ///<seealso cref = "Domain.Interfaces.IDeckService">
    /// Method documentation at the interface.
    ///</seealso>
    public class DeckService : IDeckService
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

        public DeckService()
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
                    Suit = (CardSuit)suit,
                    Rank = (CardRank)rank
                })));

            //Shuffle the new deck
            Shuffle();
        }

        public void Shuffle()
        {
            int cardsCount = Cards.Count;

            //Shuffle the ammount of times defined in _shuffleTimes.
            for (int i = 0; i < _shuffleTimes; i++)
            {

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
            if (Cards.Count == 0)
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
        public List<Card> Draw(int count)
        {
            //Init
            List<Card> drawnCardList = new List<Card>();

            for (int i = 0; i < count; i++)
            {
                drawnCardList.Add(Draw());
            }

            return drawnCardList;
        }
    }
}
