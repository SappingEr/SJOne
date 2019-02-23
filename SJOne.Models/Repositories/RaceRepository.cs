using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
