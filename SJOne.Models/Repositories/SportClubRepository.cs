using NHibernate;
using SJOne.Models.Filters;

namespace SJOne.Models.Repositories
{
    [Repository]
    public class SportClubRepository: Repository<SportClub, SportClubFilter>
    {
        public SportClubRepository(ISession session) :
           base(session)
        {
        }
    }
}
