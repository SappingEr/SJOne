using Microsoft.AspNet.Identity.Owin;
using SJOne.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web;

namespace SJOne.Auth
{
    public class SignInManager: SignInManager<User, long>
    {
        public SignInManager(UserManager<User, long> userManager, IAuthenticationManager authenticationManager)
            :base(userManager, authenticationManager)
        {
        }

        public void SignOut()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}