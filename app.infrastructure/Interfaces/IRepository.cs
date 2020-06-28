using System;
using System.Collections.Generic;
using app.core.BaseEntities;
using app.core.Entities;

namespace app.infrastructure.Interfaces
{
    public interface IRepository<T, in IdType>
        where T : BaseEntity<IdType>
        where IdType : IComparable
    {
        IEnumerable<T> GetAll();
        T GetById(IdType id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(IdType i);
        IEnumerable<T> Search(Func<T, bool> condition);
    }
}