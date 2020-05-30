using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.Domain.GameLogic;
using BlackJack.Domain.Interfaces;
using BlackJack.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.MVC.Controllers
{
    public class BlackJackGameController : Controller
    {
        private readonly IBlackJackGameService _blackJackGameService;

        public BlackJackGameController(IBlackJackGameService blackJackGameService)
        {
            _blackJackGameService = blackJackGameService;
        }

        public IActionResult Game(string button = "Deal")
        {
            switch (button)
            {
                case "Deal":
                    _blackJackGameService.Deal(10);
                    return View(GetGameState());
                case "Hit":
                    _blackJackGameService.Hit();
                    return View(GetGameState());
                case "Stand":
                    _blackJackGameService.Stand();
                    return View(GetGameState());
                case "Fold":
                    _blackJackGameService.EndGame();
                    return View(GetGameState());
                default:
                    return View();
            }

            //Enum.TryParse<GameAction>(gameAction, out GameAction action);

                //switch (action)
                //{
                //    case GameAction.Deal:
                //        _blackJackGameService.Deal(10);
                //        break;

                //    case GameAction.Hit:
                //        _blackJackGameService.Hit();
                //        break;

                //    case GameAction.Stand:
                //        _blackJackGameService.Stand();
                //        break;

                //    case GameAction.Fold:
                //        _blackJackGameService.EndGame();
                //        break;  
                //}

                //if (GetGameState() != null)
                //{
                //    return View(GetGameState());
                //}
                //else
                //{
                //    return View(new ErrorViewModel());
                //}

           
        }

        private GameState GetGameState()
        {
            return _blackJackGameService.GameState;
        }
    }
}