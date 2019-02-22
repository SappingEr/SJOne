using Microsoft.AspNet.Identity;
using SJOne.Models;

namespace SJOne.Auth
{
    public class RoleManager: RoleManager<Role, long>
    {
        public RoleManager(IRoleStore<Role, long> store): base(store)
        {
            RoleValidator = new RoleValidator<Role, long>(this);
        }
    }
}