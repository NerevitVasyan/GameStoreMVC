using AutoMapper;
using GameStoreMVC.BLL.DtoModels;
using GameStoreMVC.BLL.Filters;
using GameStoreMVC.BLL.Services.Abstraction;
using GameStoreMVC.DAL.Entities;
using GameStoreMVC.DAL.Repository;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameStoreMVC.BLL.Services.Implementation
{
    public class GameService : IGameService
    {
        private readonly IRepository<Game> repository;
        private readonly IRepository<Producer> repositoryProd;
        private readonly IMapper mapper;

        public GameService(IRepository<Game> _repository,
                           IRepository<Producer> _repositoryProd,
                           IMapper _mapper)
        {
            repository = _repository;
            repositoryProd = _repositoryProd;
            mapper = _mapper;
        }

        public async Task<ICollection<GameDto>> GetGames(List<GameFilter> filters = null)
        {
            IEnumerable<Game> games;

            if (filters != null)
            {

                var exp = filters[0].Expression;

                for (int i = 1; i < filters.Count; i++)
                {
                    exp = exp.Or(filters[i].Expression);
                }

                games = await repository.GetWhere(exp);
            }
            else
            {
                games = await repository.GetAll();
            }


            return mapper.Map<IEnumerable<Game>, ICollection<GameDto>>(games);
        }

        /// <summary>
        /// Add new Game
        /// </summary>
        /// <param name="game">New game</param>
        /// <returns></returns>
        public async Task AddGame(GameDto game)
        {
            var prod = await repositoryProd.FirstOrDefault(x => x.Name == game.Producer.Name);
            if(prod==null)
            {
                return;
            }

            Game g = new Game
            {
                Name = game.Name,
                Producer = prod,
                Year = game.Year
            };

            await repository.Add(g);
        }
    }
}
