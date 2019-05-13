using NHibernate;
using NHibernate.Criterion;
using SJOne.Models.Filters;
using System.Collections.Generic;

namespace SJOne.Models.Repositories
{
    [Repository]
    public class StartNumberRepository : Repository<StartNumber, StartNumberFilter>
    {
        public StartNumberRepository(ISession session) : base(session)
        {

        }

        public IList<StartNumber> JudgeAthletesList(Judge judge)
        {
            var crit = session.CreateCriteria<StartNumber>()
                .Add(Restrictions.Eq("Judge", judge))
                .CreateCriteria("User");
            return crit.List<StartNumber>();
        }
    }
}
