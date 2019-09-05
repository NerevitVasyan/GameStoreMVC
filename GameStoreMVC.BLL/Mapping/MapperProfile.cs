using AutoMapper;
using GameStoreMVC.BLL.DtoModels;
using GameStoreMVC.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoreMVC.BLL.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Producer, ProducerDto>();
            CreateMap<Game, GameDto>();
        }
    }
}
