using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Game.Exceptions
{
    class CardRankException : Exception
    {
        public CardRankException()
        {
        }

        public CardRankException(string message) : base(message)
        {
        }

        public CardRankException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
