﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Domain.GameLogic
{
    public class GameState
    {
        Player DefaultPlayer { get; set; }
        Player Dealer { get; set; }
        State CurrentState { get; set; }
    }
}
