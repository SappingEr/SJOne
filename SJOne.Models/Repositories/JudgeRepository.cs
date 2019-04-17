using NHibernate;
using NHibernate.Criterion;
using SJOne.Models.Filters;
using System.Collections;
using System.Collections.Generic;

namespace SJOne.Models.Repositories
{
    [Repository]
    public class JudgeRepository : Repository<Judge, JudgeFilter>
    {
        public JudgeRepository(ISession session) : base(session)
        {
        }

        public IList<StartNumber> GetTimings()
        {
            var crit = session.CreateCriteria<StartNumber>()
                .CreateCriteria("HandTimings")
                .SetProjection(Projections.Max("Lap"));
            return crit.List<StartNumber>();
        }
    }
}
