using NHibernate;


namespace SJOne.Models.Repositories
{
    [Repository]
    public class HandTimingRepository : Repository<HandTiming, HandTimingFilter>
    {
        public HandTimingRepository(ISession session) : base(session)
        {
        }
    }
}
