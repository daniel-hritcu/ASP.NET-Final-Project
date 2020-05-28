using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Domain.PlayingCard;
using BlackJack.StandardDeck;
using BlackJack.StandardDeck.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlackJack.UnitTests.StandardDeck
{
    [TestClass]
    public class DeckTests
    {
        Deck deck;
        
        [TestMethod]
        public void Deck_Constructor_Has52Cards()
        {
            deck = new Deck();

            int expectedCardCount = 52;
            int actualCardCount = deck.Cards.Count;

            Assert.AreEqual(expectedCardCount, actualCardCount);
        }

        [TestMethod]
        public void Deck_Constructor_HasNoDuplicateCards()
        {
            deck = new Deck();

            //Count duplicate cards in deck. Return false if none.
            bool hasDuplicateCards = deck.Cards
                .GroupBy(x => new { x.Rank, x.Suit })
                .Where(x => x.Skip(1).Any()).Any();

            Assert.IsFalse(hasDuplicateCards);
        }

        [TestMethod]
        public void Draw_FromNonEmptyDeck_Get1Card()
        {
            deck = new Deck();

            Card expectedCard = deck.Draw();

            Assert.IsNotNull(expectedCard);
        }

        [TestMethod]
        [ExpectedException(typeof(EmptyDeckException), "Deck does not have any cards.")]
        public void Draw_FromEmptyDeck_ThowsEmptyDeckException()
        {
            deck = new Deck();

            //Clear cards from deck
            deck.Cards = new List<Card>();
            //Draw card from empty deck;
            deck.Draw();
        }

        [TestMethod]
        public void Shuffle_NewDeck_GetShuffledDeck()
        {
            deck = new Deck();
            List<Card> firstDeckCards = new List<Card>();
            List<Card> secondDeckCards = new List<Card>();

            //Save first deck cards
            firstDeckCards.AddRange(deck.Cards);
            //Shuffle deck
            deck.Shuffle();
            //Save new deck cards
            secondDeckCards.AddRange(deck.Cards);

            //first deck should not be equal to new deck
            Assert.AreNotEqual(firstDeckCards, secondDeckCards);
        }

    }
}
