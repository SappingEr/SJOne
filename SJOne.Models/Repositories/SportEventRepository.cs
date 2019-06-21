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
    }
}
