using NHibernate;
using SJOne.Models.Filters;

namespace SJOne.Models.Repositories
{
    [Repository]
    public class SportEventRepository : Repository<SportEvent, SportEventFilter>
    {
        public SportEventRepository(ISession session) :
            base(session)
        {
        }
    }
}
