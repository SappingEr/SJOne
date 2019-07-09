using NHibernate;
using NHibernate.Criterion;
using SJOne.Models.Filters;
using System.Collections.Generic;

namespace SJOne.Models.Repositories
{
    [Repository]
    public class CityRepository: Repository<Locality, LocalityFilter>
    {
        public CityRepository(ISession session) : base(session)
        {
        }        
    }
}
