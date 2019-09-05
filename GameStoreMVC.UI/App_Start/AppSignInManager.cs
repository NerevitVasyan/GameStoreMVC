using GameStoreMVC.DAL.Entities;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameStoreMVC.UI.App_Start
{
    public class AppSignInManager : SignInManager<AppUser,string>
    {
        public AppSignInManager(AppUserManager userManager, IAuthenticationManager authenticationManager)
        : base(userManager, authenticationManager)
        {
        }


        public static AppSignInManager Create(IdentityFactoryOptions<AppSignInManager> options, IOwinContext context)
        {
            return new AppSignInManager(context.GetUserManager<AppUserManager>(), context.Authentication);
        }

    }
}