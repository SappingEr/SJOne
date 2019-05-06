using NHibernate;
using SJOne.Models.Filters;

namespace SJOne.Models.Repositories
{
    [Repository]
    public class StartNumberRepository : Repository<StartNumber, StartNumberFilter>
    {
        public StartNumberRepository(ISession session) : base(session)
        {

        }
    }
}
