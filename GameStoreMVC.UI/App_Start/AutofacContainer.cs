using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using GameStoreMVC.BLL.Mapping;
using GameStoreMVC.BLL.Services.Abstraction;
using GameStoreMVC.BLL.Services.Implementation;
using GameStoreMVC.DAL;
using GameStoreMVC.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameStoreMVC.UI.App_Start
{
    public class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            RegisterDependencies(builder);

            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }

        private static void RegisterDependencies(ContainerBuilder builder)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });

            IMapper mapper = new Mapper(mapperConfig);

            builder.RegisterInstance(mapper).As<IMapper>();

            builder.RegisterType<GamesContext>().As<DbContext>().SingleInstance();

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));

            builder.RegisterType<GameService>().As<IGameService>();

        }

    }
}