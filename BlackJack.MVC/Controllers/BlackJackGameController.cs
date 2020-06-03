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
        private GameState _gameState;

        public BlackJackGameController(IBlackJackGameService blackJackGameService)
        {
            _blackJackGameService = blackJackGameService;
        }

        public IActionResult Game(string button = "New Game")
        {
            switch (button)
            {
                case "New Game":
                    _gameState = _blackJackGameService.NewGame();
                    break;
                case "Deal":
                    _gameState = _blackJackGameService.Deal(10);
                    break;
                case "Hit":
                    _gameState = _blackJackGameService.Hit();
                    break;
                case "Stand":
                    _gameState = _blackJackGameService.Stand();
                    break;
                default:
                    _gameState = null;
                    break;
            }

            if (_gameState == null) 
            {
                return View(_blackJackGameService.NewGame());
            }

            return View(_gameState);
        }
    }
}