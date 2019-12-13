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
    }
}
