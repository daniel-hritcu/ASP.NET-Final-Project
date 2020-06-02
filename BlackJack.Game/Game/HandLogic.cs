using BlackJack.Domain;

namespace BlackJack.Game.Game
{
    /// <summary>
    /// Provides basic bool methods to check hand win/loss state.
    /// </summary>
    internal static class HandLogic
    {
        /// <summary>
        /// Checks a player has a blackjack.
        /// </summary>
        /// <param name="player">
        /// The player to be checked.
        /// </param>
        /// <returns>
        /// True:   If Score is 21.
        /// False:  If not.
        /// </returns>
        internal static bool HasBlackJack(Player player)
        {
            return player.Score == 21;
        }

        /// <summary>
        /// Checks a player has busted
        /// </summary>
        /// <param name="player">
        /// The player to be checked.
        /// </param>
        /// <returns>
        /// True:   If player's score is greater than 21.
        /// False:  If not.
        /// </returns>
        internal static bool IsBust(Player player)
        {
            return player.Score > 21;
        }

        /// <summary>
        /// Checks if the firstPlayer has a higher score than the secondPlayer
        /// </summary>
        /// <param name="firstPlayer">Player to check</param>
        /// <param name="secondPlayer">Player to check</param>
        /// <returns>
        /// True:   If firstPlayer score is higher than the player.
        /// False:  If not.
        /// </returns>
        internal static bool IsHandHigh(Player firstPlayer, Player secondPlayer)
        {
            return firstPlayer.Score > secondPlayer.Score;
        }

        /// <summary>
        /// Checks if dealer has hit up to 17 points or greater.
        /// </summary>
        /// <param name="dealer"></param>
        /// <returns></returns>
        internal static bool IsSoft17(Player dealer)
        {
            return dealer.Score >= 17;
        }

        internal static bool IsWin(Player player, Player dealer)
        {
            return IsBust(dealer) && !IsBust(player) || !IsBust(player) && IsHandHigh(player, dealer);
        }

        internal static bool IsPush(Player player, Player dealer)
        {
            return player.Score == dealer.Score;
        }

        internal static bool IsBlackJack(Player player, Player dealer)
        {
            return HasBlackJack(player) && !HasBlackJack(dealer);
        }
    }
}
