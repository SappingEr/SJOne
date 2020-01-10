using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using SJOne.Models;
using SJOne.Models.Repositories;
using System;
using Microsoft.AspNet.Identity;

namespace SJOne.Controllers
{

    public class AccountController : BaseController
    {

        public AccountController(UserRepository userRepository) : base(userRepository)
        {
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Register()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }

            else
            {
                return RedirectToAction("Start", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel registerModel)
        {
            if (ModelState.IsValid && !User.Identity.IsAuthenticated)
            {
                var user = new User { UserName = registerModel.Login };
                var result = UserManager.CreateAsync(user, registerModel.Password);

                if (result.Result.Succeeded)
                {
                    UserManager.AddToRoleAsync(user.Id, "User");

                    userRepository.InvokeInTransaction(() =>
                    {
                        user.RegistrationDate = DateTime.Now.Date;
                        user.Status = Status.Active;
                    });                    
                    
                    SignInManager.SignIn(user, false, false);
                    return RedirectToAction("Start", "Home");
                }
                else
                {
                    foreach (var error in result.Result.Errors)
                    {
                        ModelState.AddModelError("", "Логин занят, введите данные заново");
                    }
                }
            }
            return View(registerModel);
        }


        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid && !User.Identity.IsAuthenticated)
            {
                var result = SignInManager.PasswordSignInAsync(loginModel.Login,
                loginModel.Password, loginModel.RememberMe, false).Result;

                switch (result)
                {
                    case SignInStatus.Success:
                        var status = UserManager.FindByNameAsync(loginModel.Login).Result.Status;
                        if (status == Status.Blocked)
                        {
                            ModelState.AddModelError("", "Аккаунт заблокирован администратором");
                            SignInManager.SignOut();
                            return View(loginModel);
                        }
                        return RedirectToBackUrl();

                    case SignInStatus.Failure:
                        ModelState.AddModelError("", "Неверный логин или пароль");
                        break;
                }
            }
            return View(loginModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            SignInManager.SignOut();
            return RedirectToAction("Start", "Home");
        }        
    }
}