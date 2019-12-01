using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Framework_Domain;
using NHibernate;

namespace Framework.Nhibernate
{
    public class BaseRepository<TKey, T> : IRepository<TKey, T> where T : IAggregateRoot
    {
        public readonly ISession Session;

        public BaseRepository(ISession session)
        {
            Session = session;
        }

        public void Create(T aggregate)
        {
            Session.Save(aggregate);
        }

        public void Update(T aggregate)
        {
            Session.Update(aggregate);
        }

        public void Delete(T aggregate)
        {
            Session.Delete(aggregate);
        }

        public void Evict(T aggregate)
        {
            Session.Evict(aggregate);
        }

        public T Get(TKey id)
        {
            return Session.Get<T>(id);
        }

        public List<T> Get(params Expression<Func<T, bool>>[] predicates)
        {
            var query = Session.Query<T>().AsQueryable();
            query = predicates.Aggregate(query, (current, predicate) => current.Where(predicate));
            return query.ToList();
        }

        public List<T> GetAll()
        {
            return Session.Query<T>().ToList();
        }

        public long GetNextId(string sequenceName)
        {
            return Session.GetNextSequence(sequenceName);
        }

        public bool IsDuplicated(params Expression<Func<T, bool>>[] predicates)
        {
            var entities = Get(predicates);
            return entities.Count > 0;
        }

        public bool Exists(params Expression<Func<T, bool>>[] predicates)
        {
            var entities = Get(predicates);
            return entities.Any();
        }

        public void BeginTran()
        {
            Session.Transaction.Begin();
        }

        public void CommitTran()
        {
            Session.Transaction.Commit();
        }

        public void RoleBack()
        {
            Session.Transaction.Rollback();
        }
    }
}