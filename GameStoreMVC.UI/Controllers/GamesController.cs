using GameStoreMVC.BLL.DtoModels;
using GameStoreMVC.BLL.Filters;
using GameStoreMVC.BLL.Services.Abstraction;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GameStoreMVC.UI.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGameService gameService;

        private const int GamesPerPage = 5;

        private List<GameFilter> GameFilters;

        public GamesController(IGameService _gameService)
        {
            gameService = _gameService;

          
        }

        //  Games/Index?page=2

        public async Task<ActionResult> Index(int page = 1)
        {
            ViewBag.Producers = new List<string>
            {
                "Blizzard",
                "Bethesda",
                "Cd Project Red",
                "Ubisoft"
            };

          

            var games = await gameService.GetGames();

            return View(games.ToPagedList(page, GamesPerPage));
        }

        public string SomeAction()
        {
            Thread.Sleep(2000);
            return "HELLO AJAX";
        }

        public async Task<PartialViewResult> GetGame(string gameName,int page=1)
        {

            var games = await gameService.GetGames();

            var result = games.Where(x => x.Name.Contains(gameName));

            return PartialView("GameView",result.ToPagedList(page, GamesPerPage));
        }

        public async Task<PartialViewResult> GetGamesByProducers(string producerName)
        {

            if (Session["Filters"] != null)
            {
                GameFilters = Session["Filters"] as List<GameFilter>;
            }
            else
            {
                GameFilters = new List<GameFilter>();
            }

            var filter = new GameFilter
            {
                Name = producerName,
                Expression = x => x.Producer.Name == producerName
            };

            GameFilters.Add(filter);
            Session["Filters"] = GameFilters;



            var games = await gameService.GetGames(GameFilters);


            return PartialView("GameView");
        }

    }
}