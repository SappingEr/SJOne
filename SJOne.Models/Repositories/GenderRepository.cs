using NHibernate;
using SJOne.Models.Filters;

namespace SJOne.Models.Repositories
{
    [Repository]
    public class GenderRepository: Repository<Gender, GenderFilter>
    {
        public GenderRepository(ISession session) :
           base(session)
        {
        }
    }
}
