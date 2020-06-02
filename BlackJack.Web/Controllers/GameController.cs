using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.Domain.GameLogic;
using BlackJack.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IBlackJackGameService _blackJackGameService;

        public GameController(IBlackJackGameService blackJackGameService)
        {
            _blackJackGameService = blackJackGameService;
        }

        [HttpGet]
        public GameState Get(string action, int bet = 0)
        {
            switch (action)
            {
                case "Bet":
                    if (bet != 0)
                        return _blackJackGameService.Deal(bet);
                    break;

                case "Hit":
                    return _blackJackGameService.Hit();

                case "Stand":
                    return _blackJackGameService.Stand();

                case "NewGame":
                default:
                    _blackJackGameService.NewGame();
                    return _blackJackGameService.Deal(10);
            }

            return _blackJackGameService.NewGame();
        }
    }
}
