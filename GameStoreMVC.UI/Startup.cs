using System;
using System.Threading.Tasks;
using GameStoreMVC.DAL;
using GameStoreMVC.DAL.Entities;
using GameStoreMVC.UI.App_Start;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(GameStoreMVC.UI.Startup))]

namespace GameStoreMVC.UI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<GamesContext>(GamesContext.Create);

            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);

            app.CreatePerOwinContext<AppSignInManager>(AppSignInManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                //Если нет прав то редирект по ссылке
                LoginPath = new PathString("/Account/Login")
                
            });

            //var db = GamesContext.Create();
            //var db1 = new GamesContext();

        }
    }
}
