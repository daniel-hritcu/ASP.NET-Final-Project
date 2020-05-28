﻿using BlackJack.Domain;
using BlackJack.Domain.GameLogic;
using BlackJack.Domain.Interfaces;
using BlackJack.Domain.PlayingCard;
using BlackJack.StandardDeck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlackJack.Game
{
    public class BlackJackGameService : IBlackJackGameService
    {
        public GameState GameState { get; set; }

        private Player _defaultPlayer;
        private Player _dealer;
        private DeckService _deckService;

        //Player starts with 500$ by default.
        private readonly int DEFAULT_BALANCE = 500;

        public BlackJackGameService()
        {
            //Init Player
            _defaultPlayer = new Player() { Balance = DEFAULT_BALANCE };
            //Init Dealer
            _dealer = new Player();
            //Init Deck
            _deckService = new DeckService();
        }

        public void Deal(int bet)
        {
            //Clear player hands
            _defaultPlayer.Hand = new List<Card>();
            _dealer.Hand = new List<Card>();
            //At the beginning of each hand, 
            //the dealer deals two cards to the player and two cards to himself.
            _defaultPlayer.Hand.AddRange(_deckService.Draw(2));
            _dealer.Hand.AddRange(_deckService.Draw(2));

            //Update GameState
            GameState = new GameState(_defaultPlayer, _dealer);
        }

        public void EndGame()
        {
            //If the dealer has a total of less than 17 points, he must hit.
            while (_dealer.Score < 17)
            {
                _dealer.Hand.Add(_deckService.Draw());
            }

            //If dealer busted, but player did not.
            //Or if player score is bigger than dealer.
            //Player wins.
            if ((IsBust(_dealer.Score) && !IsBust(_defaultPlayer.Score))||
                (_defaultPlayer.Score > _dealer.Score))
            {
                GameState.CurrentState = State.Win;
            }

            //In case of a tie, the player's bet is returned
            else if (_defaultPlayer.Score == _dealer.Score)
            {
                GameState.CurrentState = State.Push;
            }
            //Player has lost
            else 
            {
                GameState.CurrentState = State.Loss;
            }

        }

        public void CalculateScore(Player player)
        {
            int score = 0;

            if (player.Hand == null)
                return;
            //Add non Ace cards
            foreach (Card nonAceCard in player.Hand.Where(card => card.Rank != CardRank.Ace))
            {
                score += CardValue(nonAceCard);
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

        public void Hit()
        {
            _defaultPlayer.Hand.Add(_deckService.Draw());
            CalculateScore(_defaultPlayer);

            if (IsBust(_defaultPlayer.Score))
            {
                GameState.CurrentState = State.Bust;
            }
            else if (IsBlackJack(_defaultPlayer.Score))
            {
                GameState.CurrentState = State.BlackJack;
            }
        }

        public void Stand()
        {
            EndGame();
        }

        private bool IsBlackJack(int score)
        {
            return score == 21;
        }

        private bool IsBust(int score)
        {
            return score > 21;
        }

        private int CardValue(Card card)
        {
            int value;
            switch (card.Rank)
            {
                //Face value cards
                case CardRank.Two:
                    value = 2;
                    break;
                case CardRank.Three:
                    value = 3;
                    break;
                case CardRank.Four:
                    value = 4;
                    break;
                case CardRank.Five:
                    value = 5;
                    break;
                case CardRank.Six:
                    value = 6;
                    break;
                case CardRank.Seven:
                    value = 7;
                    break;
                case CardRank.Eight:
                    value = 8;
                    break;
                case CardRank.Nine:
                    value = 9;
                    break;
                //Face cards
                case CardRank.Ten:
                case CardRank.Jack:
                case CardRank.Queen:
                case CardRank.King:
                    value = 10;
                    break;
                //Ace
                case CardRank.Ace:
                    value = 11;
                    break;
                default:
                    value = 0;
                    break;
            }

            return value;
        }
    }
}
