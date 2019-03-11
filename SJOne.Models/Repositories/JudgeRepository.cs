using NHibernate;
using SJOne.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJOne.Models.Repositories
{
    [Repository]
    public class JudgeRepository : Repository<Judge, JudgeFilter>
    {
        public JudgeRepository(ISession session) : base(session)
        {
        }
    }
}
