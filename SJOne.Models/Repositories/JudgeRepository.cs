using NHibernate;
using NHibernate.Criterion;
using SJOne.Models.Filters;
using System.Collections;
using System.Collections.Generic;

namespace SJOne.Models.Repositories
{
    [Repository]
    public class JudgeRepository :  Repository<Judge, JudgeFilter>
    {
        public JudgeRepository(ISession session) : base(session)
        {            
        }     


        public IList<User> JudgeAthletesList(Judge judge)
        {
            var crit = session.CreateCriteria<User>()
                .Add(Restrictions.Eq("Judge", judge))
                .CreateCriteria("StartNumbersJ");
            return crit.List<User>();
        }

    }
}
