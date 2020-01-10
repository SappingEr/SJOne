using Microsoft.AspNet.Identity.Owin;
using SJOne.Auth;
using SJOne.Models;
using SJOne.Models.Repositories;
using System.Web;
using System.Web.Mvc;

namespace SJOne.Controllers
{
    public class BaseController : Controller
    {
        protected UserRepository userRepository;

        public BaseController(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public SignInManager SignInManager => HttpContext.GetOwinContext().Get<SignInManager>();

        public UserManager UserManager => HttpContext.GetOwinContext().GetUserManager<UserManager>();

        public RoleManager RoleManager => HttpContext.GetOwinContext().Get<RoleManager>();

        public User CurrentUser => userRepository.GetCurrentUser(User);

        [HttpGet]
        public virtual ActionResult RedirectToBackUrl()
        {
            var backUrl = Request["ReturnUrl"];
            var redirectUrl = !string.IsNullOrEmpty(backUrl) ? backUrl : Url.Action("Start");
            return Redirect(redirectUrl);
        }
    }
}