using System;
using System.Collections.Generic;
using app.core.Models;
using app.infrastructure.Models;

namespace app.infrastructure.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(Guid id);
    }
}