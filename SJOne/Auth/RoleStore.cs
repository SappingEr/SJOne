using Microsoft.AspNet.Identity;
using NHibernate;
using SJOne.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SJOne.Auth
{
    public class RoleStore : IRoleStore<Role, long>, IQueryableRoleStore<Role, long>
    {
        private readonly ISession session;

        public RoleStore(ISession session)
        {
            this.session = session;
        }

        public IQueryable<Role> Roles
        {
            get
            {
                var crit = session.CreateCriteria<Role>();
                return crit.List<Role>().AsQueryable();
            }
        }

        public Task CreateAsync(Role role)
        {
            session.Save(role);
            session.Flush();
            return Task.FromResult(0);
        }

        public Task DeleteAsync(Role role)
        {
            session.Delete(role);
            session.Flush();
            return Task.FromResult(0);
        }

        public void Dispose()
        {
            
        }

        public Task<Role> FindByIdAsync(long roleId)
        {
            return Task.FromResult(session.Get<Role>(roleId));
        }

        public Task<Role> FindByIdAsync(string roleId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Role> FindByNameAsync(string roleName)
        {
            return Task.FromResult(session.QueryOver<Role>().Where(r => r.Name == roleName).SingleOrDefault());
        }

        public Task UpdateAsync(Role role)
        {
            session.Update(role);
            session.Flush();
            return Task.FromResult(0);
        }
    }
}