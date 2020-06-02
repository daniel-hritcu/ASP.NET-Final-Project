using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Game.Exceptions
{
    class GameStateException : Exception
    {
        public GameStateException()
        {
        }

        public GameStateException(string message) : base(message)
        {
        }

        public GameStateException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
