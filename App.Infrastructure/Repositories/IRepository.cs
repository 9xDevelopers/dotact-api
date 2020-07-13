using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Core.Models;

namespace App.Infrastructure.Repositories
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