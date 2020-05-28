using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.StandardDeck.Exceptions
{
    public class EmptyDeckException : Exception
    {
        public EmptyDeckException()
        {
        }

        public EmptyDeckException(string message) : base(message)
        {
        }

        public EmptyDeckException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
