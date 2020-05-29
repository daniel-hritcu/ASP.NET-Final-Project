using System.Collections.Generic;
using System.Linq;
using BlackJack.Domain.PlayingCard;
using BlackJack.StandardDeck;
using BlackJack.StandardDeck.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlackJack.UnitTests.StandardDeck
{
    [TestClass]
    public class DeckServiceTests
    {
        DeckService _deckService;
        
        [TestMethod]
        public void DeckService_Constructor_Has52Cards()
        {
            _deckService = new DeckService();

            int expectedCardCount = 52;
            int actualCardCount = _deckService.Cards.Count;

            Assert.AreEqual(expectedCardCount, actualCardCount);
        }

        [TestMethod]
        public void DeckService_Constructor_HasNoDuplicateCards()
        {
            _deckService = new DeckService();

            //Count duplicate cards in deck. Return false if none.
            bool hasDuplicateCards = _deckService.Cards
                .GroupBy(x => new { x.Rank, x.Suit })
                .Where(x => x.Skip(1).Any()).Any();

            Assert.IsFalse(hasDuplicateCards);
        }

        [TestMethod]
        public void Draw_FromNonEmptyDeck_Get1Card()
        {
            _deckService = new DeckService();

            Card expectedCard = _deckService.Draw();

            Assert.IsNotNull(expectedCard);
        }

        [TestMethod]
        [ExpectedException(typeof(EmptyDeckException), "Deck does not have any cards.")]
        public void Draw_FromEmptyDeck_ThowsEmptyDeckException()
        {
            _deckService = new DeckService();

            //Clear cards from deck
            _deckService.Cards = new List<Card>();
            //Draw card from empty deck;
            _deckService.Draw();
        }

        [TestMethod]
        public void Shuffle_NewDeck_GetShuffledDeck()
        {
            _deckService = new DeckService();
            List<Card> firstDeckCards = new List<Card>();
            List<Card> secondDeckCards = new List<Card>();

            //Save first deck cards
            firstDeckCards.AddRange(_deckService.Cards);
            //Shuffle deck
            _deckService.Shuffle();
            //Save new deck cards
            secondDeckCards.AddRange(_deckService.Cards);

            //first deck should not be equal to new deck
            Assert.AreNotEqual(firstDeckCards, secondDeckCards);
        }

    }
}
