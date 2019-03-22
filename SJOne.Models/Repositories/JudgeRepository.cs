using NHibernate;
using SJOne.Models.Filters;

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
