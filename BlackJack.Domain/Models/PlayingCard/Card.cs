using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Domain.PlayingCard
{
    public class Card
    {
        public string Name { get=>this.ToString(); }
        public CardRank Rank { get; set; }
        public CardSuit Suit { get; set; }

        public override string ToString()
        {
            //If it's a blank card
            if (Rank == CardRank.Back)
            {
                return Rank.ToString();
            }

            return $"{Rank}Of{Suit}";
        }
    }
}
