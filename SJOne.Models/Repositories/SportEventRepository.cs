using NHibernate;
using SJOne.Models.Filters;
using System.Collections.Generic;

namespace SJOne.Models.Repositories
{
    [Repository]
    public class SportEventRepository: Repository <SportEvent, SportEventFilter>
    {
        public SportEventRepository(ISession session) :
            base(session)
        {
        }


        public IList<SportEvent> Find(SportEventFilter filter, FetchOptions options = null)
        {
            var crit = session.CreateCriteria<SportEvent>();
            SetupFilter(filter, crit);
            SetupFetchOptions(crit, options);
            return crit.List<SportEvent>();
        }
    }
}
