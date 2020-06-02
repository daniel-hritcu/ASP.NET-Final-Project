using BlackJack.Domain;
using BlackJack.Domain.GameLogic;
using BlackJack.Domain.PlayingCard;
using BlackJack.Game.Exceptions;
using BlackJack.StandardDeck.Services;
using System.Linq;

namespace BlackJack.Game.Game
{
    internal class GameLogic
    {
        private DeckService _deckService;
        private Player _defaultPlayer;
        private Player _dealer;
        private GameState _gameState;
		private Card _hiddenCard;

		public GameLogic()
        {
            NewGame();
        }

        internal GameState NewGame(double playerBalance = 0)
        {
            //Init Deck Service
            _deckService = new DeckService();

            //Init players
            _dealer = new Player();
            _defaultPlayer = new Player();

            //Set Player balance. default if argument is zero or negative.
            _defaultPlayer.Balance = playerBalance <= 0 ? Rules.DEFAULT_BALANCE : playerBalance;

            //Init GameState
            _gameState = new GameState(_defaultPlayer, _dealer);

            return _gameState;
        }

        public GameState Deal(double bet)
        {
            //Clear last game. Make new game with old balance.
            NewGame(_defaultPlayer.Balance);

            //Try to set new bet balance
            TryPlaceBet(bet);

            //Check if insufficient funds
            if (_gameState.CurrentState == State.LowBalance)
            {
                return null;
            }

            //Shuffle a new deck
            _deckService.NewDeck();

            //At the beginning of each hand the dealer deals two cards,
            //first to the player and then to himself.
            DealFirstHands();

			//Check for BlackJack
			if (HandLogic.HasBlackJack(_defaultPlayer))
			{
				EndGame();
			}

			//Setup a new GameState
				_gameState = new GameState(_defaultPlayer, _dealer, State.Open);

            return _gameState;
        }

        public GameState Hit()
        {
            //throw Exception if Hit() is called when game state is not open.
            if (_gameState.CurrentState != State.Open)
            { 
                throw new GameStateException($"Can not call Hit() if game State is not Open. " +
                                                $"Current state is {_gameState.CurrentState.ToString()}");
            }

            //If the game has no winner, give a card to the player
            AddCardToHand(_defaultPlayer);

            //Check for player blackjack or bust
            if (HandLogic.HasBlackJack(_defaultPlayer) || HandLogic.IsBust(_defaultPlayer))
            {
                //Init the end game
                EndGame();
            }

            return _gameState;
        }

            

        public GameState Stand()
        {
            //throw Exception if Hit() is called when game state is not open.
            if (_gameState.CurrentState != State.Open)
            { 
                throw new GameStateException($"Can not call Stand() if game State is not Open. " +
                                                $"Current state is {_gameState.CurrentState.ToString()}");
            }

            EndGame();

			return _gameState;
        }

		internal void TryPlaceBet(double bet)
		{
			//new balance
			double newPlayerBalance = _defaultPlayer.Balance - bet;

			//If ballance is insufficient, return null
			if (newPlayerBalance < 0)
			{
				//Set low balance state
				_gameState.CurrentState = State.LowBalance;
			}
			else
			{
				//Set new player balance
				_defaultPlayer.Balance = newPlayerBalance;
			}
		}

		internal void DealFirstHands()
		{
			//Add 2 cards to player
			_defaultPlayer.Hand.AddRange(_deckService.Draw(2));
			CalculateScore(_defaultPlayer);

			//Add 2 cards to dealer
			_dealer.Hand.AddRange(_deckService.Draw(2));
			//Save second card
			_hiddenCard = _dealer.Hand[1];
			//Hide second card
			_dealer.Hand[1] = new Card() { Rank = CardRank.Back };
		}

		internal void AddCardToHand(Player player)
		{
			//Add a card to the specified player
			player.Hand.Add(_deckService.Draw());
			CalculateScore(player);
		}

		internal void EndGame()
		{
			//Reveal dealer second card
			_dealer.Hand[1] = _hiddenCard;

			//Calculate initial dealer score
			CalculateScore(_dealer);

			//If the dealer has a total of less than 17 points, he must hit.
			while (!HandLogic.IsSoft17(_dealer)) { AddCardToHand(_dealer); };

			//Evaluate player hands
			if (_gameState.CurrentState == State.Open)
			{
				_gameState.CurrentState = EvaluateHands();
			}

			//Pay if won
			DoPayout();
		}

		internal State EvaluateHands()
		{
			//BlackJack
			if (HandLogic.IsBlackJack(_defaultPlayer, _dealer))
			{
				return State.BlackJack;
			}
			//Win
			else if (HandLogic.IsWin(_defaultPlayer, _dealer))
			{
				return State.Win;
			}
			//Push
			else if (HandLogic.IsPush(_defaultPlayer, _dealer))
			{
				return State.Push;
			}
			//Bust
			else if (HandLogic.IsBust(_defaultPlayer))
			{
				return State.Bust;

			}
			//Loss
			else
			{
				return State.Loss;
			}

		}

		internal void DoPayout()
		{
			switch (_gameState.CurrentState)
			{
				case State.Win:
					_gameState.Winnings = _gameState.Bet * Rules.WIN_MULTIPLYER;
					break;
				case State.BlackJack:
					_gameState.Winnings = _gameState.Bet * Rules.BLACKJACK_MULTIPLIER;
					break;
				case State.Push:
					_gameState.Winnings = _gameState.Bet;
					break;
			}

			//Add win ammount if any
			_gameState.DefaultPlayer.Balance += _gameState.Winnings;
		}

		private void CalculateScore(Player player)
		{
			int score = 0;

			if (player.Hand == null)
				return;
			//Add non Ace cards
			foreach (Card nonAceCard in player.Hand.Where(card => card.Rank != CardRank.Ace))
			{
				score += GameCardValues.CardValue(nonAceCard);
			}

			//Add Ace cards while trying not to bust
			foreach (Card ace in player.Hand.Where(card => card.Rank == CardRank.Ace))
			{
				if ((score + 11) <= 21)
				{
					score += 11;
					continue;
				}
				score += 1;
			}

			player.Score = score;
		}
	}
}
