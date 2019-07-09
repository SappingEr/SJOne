using NHibernate;
using NHibernate.Criterion;
using SJOne.Models.Filters;
using System.Collections.Generic;

namespace SJOne.Models.Repositories
{
    [Repository]
    public class RegionRepository: Repository<Locality, RegionFilter>
    {
        public RegionRepository(ISession session) : base(session)
        {
        }       
    }
}
