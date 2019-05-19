using NHibernate;
using NHibernate.Criterion;
using SJOne.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.UI.WebControls;

namespace SJOne.Models.Repositories
{
    public class Repository<T, FT> 
        where T : class
        where FT : BaseFilter
    {
        protected ISession session;

        public Repository(ISession session)
        {
            this.session = session;
        }

        public virtual T Get(long id)
        {
            return session.Get<T>(id);
        }

        public virtual T Load(long id)
        {
            return session.Load<T>(id);
        }



        public virtual void Save(T entity)
        {
            session.Save(entity);
        }

        public void InvokeInTransaction(Action action)
        {
            using (var tr = session.BeginTransaction())
            {
                action.Invoke();
                tr.Commit();
            }
        }

        public void Flush()
        {
            session.Flush();
        }

        public virtual void Delete(T entity)
        {
            session.Delete(entity);
        }

        public virtual IList<T> FindAll()
        {
            var crit = session.CreateCriteria<T>();
            return crit.List<T>();
        }

        public virtual void SetupFilter(FT filter, ICriteria crit)
        {
            if (filter != null)
            {
                if (!string.IsNullOrWhiteSpace(filter.SearchString))
                {
                    SetupFastSearchFilter(crit, filter.SearchString);
                }
            }
        }

        public virtual void SetupFastSearchFilter(ICriteria crit, string searchStr)
        {
            ICriterion criterion = null;
            foreach (var prop in typeof(T).GetProperties())
            {
                var attr = prop.GetCustomAttribute<FastSearchAttribute>();
                if (attr == null)
                {
                    continue;
                }
                var likeExpresion = Restrictions.Like(prop.Name, searchStr, MatchMode.Anywhere);
                criterion = criterion == null ? likeExpresion : Restrictions.Or(criterion, likeExpresion);
            }
            if (criterion != null)
            {
                crit.Add(criterion);
            }
        }

        public virtual void SetupFetchOptions(ICriteria criteria, FetchOptions options)
        {
            if (options != null)
            {
                if (options.Start > 0)
                {
                    criteria.SetFirstResult(options.Start);
                }

                if (options.Count > 0)
                {
                    criteria.SetMaxResults(options.Count);
                }

                if (!string.IsNullOrEmpty(options.SortExpression))
                {
                    criteria.AddOrder(options.SortDirection == SortDirection.Ascending ?
                        Order.Asc(options.SortExpression) :
                        Order.Desc(options.SortExpression));
                }
            }
        }

        public IList<T> Find(FT filter, FetchOptions options = null)
        {
            var crit = session.CreateCriteria<T>();
            SetupFilter(filter, crit);
            SetupFetchOptions(crit, options);
            return crit.List<T>();
        }




    }
}
