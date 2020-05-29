using BlackJack.Domain;
using BlackJack.Domain.GameLogic;
using BlackJack.Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Tests.Game
{
    [TestClass]
    public class BlackJackGameServiceTests
    {
        public TestContext TestContext { get; set; }

        BlackJackGameService _gameService;

        double proposedBet = It.Is<double>(i => i > 0 && i < 500);
        double defaultBalance = 500;

        [TestInitialize]
        public void TestInit()
        {
            _gameService = new BlackJackGameService();
        }

        [TestMethod]
        public void BlackJackGameService_Constructor_ProperInit()
        {
            GameState _gameState = _gameService.GameState;

            Assert.IsNotNull(_gameState);
        }

        [TestMethod]
        public void Deal_Init_ProperGameStateCreation()
        {
            _gameService.Deal(proposedBet);

            Assert.IsNotNull(_gameService.GameState);
            Assert.IsNotNull(_gameService.GameState.DefaultPlayer);
            Assert.IsNotNull(_gameService.GameState.Dealer);
            Assert.AreEqual(_gameService.GameState.CurrentState, Domain.GameLogic.State.Open);
        }

        [TestMethod]
        public void Deal_Init_Deals2CardsToEachPlayer()
        {
            _gameService.Deal(proposedBet);

            int expectedCardCount = 2;

            int actualCardCountPlayer = _gameService.GameState.DefaultPlayer.Hand.Count;
            int actualCardCountDealer = _gameService.GameState.DefaultPlayer.Hand.Count;

            Assert.AreEqual(expectedCardCount, actualCardCountPlayer);
            Assert.AreEqual(expectedCardCount, actualCardCountDealer);
        }

        [TestMethod]
        public void Deal_Init_SetsCorrectPlayerBalance()
        {
            _gameService.Deal(proposedBet);

            double expectedBalance = defaultBalance - proposedBet;
            double actualBalance = _gameService.GameState.DefaultPlayer.Balance;

            Assert.AreEqual(expectedBalance, actualBalance);
        }

        [TestMethod]
        public void Deal_WithBetBiggerThanBudget_SetsCorrectGameState()
        {
            //Deal past the default balance
            _gameService.Deal(defaultBalance + 1);

            State expectedState = State.LowBalance;
            State actualState = _gameService.GameState.CurrentState;

            Assert.AreEqual(expectedState, actualState);
        }

        [TestMethod]
        public void Hit_Init_Adds1Card()
        {
            _gameService.Deal(proposedBet);
            _gameService.Hit();

            int actualCardCount = _gameService.GameState.DefaultPlayer.Hand.Count;

            int expectedCardCount = 3;

            Assert.AreEqual(expectedCardCount, actualCardCount);
        }

    }
}
