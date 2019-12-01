using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Framework_Domain
{
    public interface IRepository
    {
    }

    public interface IRepository<in TKey, T> : IRepository where T : IAggregateRoot
    {
        T Get(TKey id);
        List<T> GetAll();
        List<T> Get(params Expression<Func<T, bool>>[] predicates);
        void Create(T aggregate);
        void Update(T aggregate);
        void Delete(T aggregate);
        void Evict(T aggregate);
        long GetNextId(string sequenceName);
        bool IsDuplicated(params Expression<Func<T, bool>>[] predicates);
        bool Exists(params Expression<Func<T, bool>>[] predicates);
        void BeginTran();
        void CommitTran();
        void RoleBack();
    }
}