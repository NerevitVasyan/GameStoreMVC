using GameStoreMVC.DAL.Entities;
using GameStoreMVC.UI.App_Start;
using GameStoreMVC.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameStoreMVC.UI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserRegister model)
        {   
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Шось не так");
                return View();
            } 

            var manager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();

            var appUser = new AppUser { Email = model.Email, UserName = model.Email };

            var result = manager.Create(appUser,model.Password);

            if(result.Succeeded)
            {
                return Content(model.Email + " " + model.Password);
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public string Login(UserRegister model)
        {
            var signInManager = HttpContext.GetOwinContext().Get<AppSignInManager>();

            var res = signInManager.PasswordSignIn(model.Email, model.Password, false, false);

            if (res == SignInStatus.Success)
            {
                return "OK!!";
            }
            else
            {
                return "Error";
            }
        }


        public ActionResult SignOut()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;

            authenticationManager.SignOut();

            return RedirectToAction("Index", "Games");
        }

    }
}