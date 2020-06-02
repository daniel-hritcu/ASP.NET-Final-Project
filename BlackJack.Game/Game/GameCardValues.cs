using BlackJack.Domain.PlayingCard;
using BlackJack.Game.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Game.Game
{
    internal static class GameCardValues
    {
		internal static int CardValue(Card card)
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

				//Default: throw Exception
				default:
					throw new CardRankException($"Unsupported card rank: {card.Rank}");
			}

			//Return card rank value
			return value;
		}
	}
}
