using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Domain.GameLogic
{
    public enum State
    {
        NewGame,
        Open,
        Bust,
        BlackJack,
        Win,
        Push,
        Loss,
        LowBalance
    }
}
