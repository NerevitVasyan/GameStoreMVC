using GameStoreMVC.BLL.DtoModels;
using GameStoreMVC.BLL.Services.Abstraction;
using GameStoreMVC.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GameStoreMVC.UI.Controllers
{
    [Authorize(Roles ="ADMIN")]
    public class AdminController : Controller
    {
        private readonly IGameService gamesService;

        public AdminController(IGameService _gameService)
        {
            gamesService = _gameService;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult AddGame()
        {
            return PartialView("AddGameForm");
        }

        [HttpPost]
        public async Task<PartialViewResult> AddGame(GameViewModel model)
        {
            GameDto game = new GameDto()
            {
                Name = model.Name,
                Year = model.Year,
                Producer = new ProducerDto { Name = model.Producer}
            };

            await gamesService.AddGame(game);

            return PartialView("AddGameForm");
        }

    }
}