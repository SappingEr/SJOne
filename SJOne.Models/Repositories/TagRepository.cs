using NHibernate;
using NHibernate.Criterion;
using SJOne.Models.Filters;
using System.Collections.Generic;

namespace SJOne.Models.Repositories
{
    [Repository]
    public class TagRepository: Repository<Tag, TagFilter>
    {
        public TagRepository(ISession session) :
           base(session)
        {
        }

        public IList<Tag> TagsByNames(string[] tagNames)
        {
            var crit = session.CreateCriteria<Tag>()
                .Add(Restrictions.In("Name", tagNames));
            return crit.List<Tag>();
        }

    }
}
