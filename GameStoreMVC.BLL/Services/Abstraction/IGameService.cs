using GameStoreMVC.BLL.DtoModels;
using GameStoreMVC.BLL.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoreMVC.BLL.Services.Abstraction
{
    public interface IGameService
    {
        Task<ICollection<GameDto>> GetGames(List<GameFilter> filters = null);

        Task AddGame(GameDto game);
    }
}
