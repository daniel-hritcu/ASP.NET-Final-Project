using BlackJack.Domain.PlayingCard;
using BlackJack.StandardDeck.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.StandardDeck
{
    public class Deck : IStandardDeck
    {
        /// <summary>
        /// The list of cards in the deck.
        /// </summary>
        public List<Card> Cards { get; set; }

        /// <summary>
        /// Provides access to deck operations
        /// </summary>
        public DeckOperations DeckOperations;

        public Deck()
        {
            //Generate new deck
            Setup();

            //Init DeckOperations
            DeckOperations = new DeckOperations(Cards);
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
            DeckOperations.Shuffle();
        }
    }
}
