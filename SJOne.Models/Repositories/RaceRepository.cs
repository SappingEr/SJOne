using NHibernate;
using SJOne.Models.Filters;

namespace SJOne.Models.Repositories
{
    [Repository]
    public class RaceRepository: Repository<Race, RaceFilter>
    {
        public RaceRepository(ISession session) :
            base(session)
        {
        }
    }
}
