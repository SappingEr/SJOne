using Microsoft.AspNet.Identity;
using SJOne.Models;

namespace SJOne.Auth
{
    public class UserManager: UserManager<User, long>
    {
        public UserManager(IUserStore<User, long> store)
            : base(store)
        {
            UserValidator = new UserValidator<User, long>(this);
            PasswordValidator = new PasswordValidator
            {
                RequiredLength = 4
            };
        }
    }
}