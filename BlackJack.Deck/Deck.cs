using System;
using System.Linq;
using System.Collections.Generic;
using BlackJack.Domain.PlayingCard;
using BlackJack.Domain.Interfaces;
using BlackJack.StandardDeck.Exceptions;

namespace BlackJack.StandardDeck
{
    public class Deck
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
        private List<Card> Cards { get; set; }

        internal Deck()
        {
            //Generate new deck
            NewDeck();
        }

        internal void NewDeck()
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

        internal void Shuffle()
        {
            int cardsCount = Cards.Count;

            //Shuffle the ammount of times defined in _shuffleTimes.
            for (int i = 0; i < shuffleTimes; i++)
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

        internal Card Draw()
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

        internal List<Card> Draw(int count)
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
