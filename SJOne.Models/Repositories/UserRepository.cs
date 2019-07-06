using System.Collections.Generic;
using System.Security.Principal;
using System.Web;
using SJOne.Models.Filters;
using Microsoft.AspNet.Identity;
using NHibernate;
using NHibernate.Criterion;

namespace SJOne.Models.Repositories
{
    [Repository]
    public class UserRepository : Repository<User, UserFilter>
    {
        public UserRepository(ISession session) :
            base(session)
        {
        }

        public override void SetupFilter(UserFilter filter, ICriteria criteria)
        {
            base.SetupFilter(filter, criteria);
            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.UserName))
                {
                    criteria.Add(Restrictions.Like("UserName", filter.Name, MatchMode.Anywhere));
                }

                if (!string.IsNullOrEmpty(filter.Name))
                {
                    criteria.Add(Restrictions.Like("Name", filter.Name, MatchMode.Anywhere));
                }

                if (!string.IsNullOrEmpty(filter.Surname))
                {
                    criteria.Add(Restrictions.Like("Surname", filter.Surname, MatchMode.Anywhere));
                }

                if (!string.IsNullOrEmpty(filter.Email))
                {
                    criteria.Add(Restrictions.Like("Email", filter.Email, MatchMode.Anywhere));
                }

                if (!string.IsNullOrEmpty(filter.City))
                {
                    criteria.Add(Restrictions.Like("City", filter.City, MatchMode.Anywhere));
                }

                if (!string.IsNullOrEmpty(filter.DOB.ToString()))
                {
                    criteria.Add(Restrictions.Eq("DOB", filter.DOB));
                }

                if (filter.Date != null)
                {
                    if (filter.Date.From.HasValue)
                    {
                        criteria.Add(Restrictions.Ge("RegistrationDate", filter.Date.From.Value));
                    }

                    if (filter.Date.To.HasValue)
                    {
                        criteria.Add(Restrictions.Le("RegistrationDate", filter.Date.To.Value));
                    }
                }
            }
        }

        public IList<User> FindUsersInRole(string role, UserFilter filter, FetchOptions options = null)
        {
            var crit = session.CreateCriteria<User>()
                .CreateAlias("Roles", "r")
                .Add(Restrictions.Eq("r.Name", role));
            SetupFilter(filter, crit);
            SetupFetchOptions(crit, options);
            return crit.List<User>();
        }

        public IList<User> RaceAthletesList(long[] userId, Race race, UserFilter filter, FetchOptions options = null)
        {
            var crit = session.CreateCriteria<User>()
                .Add(Restrictions.In("Id", userId));
            SetupFilter(filter, crit);
            SetupFetchOptions(crit, options);
            crit.CreateCriteria("StartNumbersU", NHibernate.SqlCommand.JoinType.LeftOuterJoin)
            .Add(Restrictions.Eq("Race", race));
            return crit.List<User>();
        }

        public User GetCurrentUser(IPrincipal user = null)
        {
            user = user ?? HttpContext.Current.User;
            if (user == null || user.Identity == null)
            {
                return null;
            }
            var currentUserId = user.Identity.GetUserId();
            long userId;
            if (string.IsNullOrEmpty(currentUserId) || !long.TryParse(currentUserId, out userId))
            {
                return null;
            }
            return Get(userId);
        }


    }
}
