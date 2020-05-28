﻿using BlackJack.Domain.PlayingCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlackJack.Domain
{
    public class Player
    {
        /// <summary>
        /// The hand of cards of the player.
        /// </summary>
        public List<Card> Hand { get; set; }

        /// <summary>
        /// The betting balance of the player
        /// </summary>
        public int Balance { get; set; }

        /// <summary>
        /// The calculated value of the hand
        /// </summary>
        public int Score { get; set; }

        public Player()
        {
            Hand = new List<Card>();
            Balance = 0;
            Score = 0;
        }
    }
}
