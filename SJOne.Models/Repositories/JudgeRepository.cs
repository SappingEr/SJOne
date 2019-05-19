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

        //public override void SetupFilter(JudgeFilter filter, ICriteria criteria)
        //{
        //    base.SetupFilter(filter, criteria);
        //    if (filter != null)
        //    {
        //        if (!string.IsNullOrEmpty(filter.Name))
        //        {
        //            criteria.Add(Restrictions.Like("Name", filter.Name, MatchMode.Anywhere));
        //        }

        //        if (!string.IsNullOrEmpty(filter.Surname))
        //        {
        //            criteria.Add(Restrictions.Like("Surname", filter.Surname, MatchMode.Anywhere));
        //        }

        //        if (!string.IsNullOrEmpty(filter.City))
        //        {
        //            criteria.Add(Restrictions.Like("City", filter.City, MatchMode.Anywhere));
        //        }                

        //        if (filter.Date != null)
        //        {
        //            if (filter.Date.From.HasValue)
        //            {
        //                criteria.Add(Restrictions.Ge("LoginStartDate", filter.Date.From.Value));
        //            }

        //            if (filter.Date.To.HasValue)
        //            {
        //                criteria.Add(Restrictions.Le("LoginStartDate", filter.Date.To.Value));
        //            }
        //        }
        //    }
        //}

        //public IList<Judge> Find(JudgeFilter filter, FetchOptions options = null)
        //{
        //    var crit = session.CreateCriteria<Judge>();
        //    SetupFilter(filter, crit);
        //    SetupFetchOptions(crit, options);
        //    return crit.List<Judge>();
        //}


        public IList<User> JudgeAthletesList(Judge judge)
        {
            var crit = session.CreateCriteria<User>()
                .Add(Restrictions.Eq("Judge", judge))
                .CreateCriteria("StartNumbersJ");
            return crit.List<User>();
        }

    }
}
