using System;
using App.Core.BaseEntities;
using App.Core.Entities;

namespace App.Infrastructure.Interfaces
{
    public interface IUnitOfWork

    {
        IAuthorRepository AuthorRepository { get; }
        IBookRepository BookRepository { get; }

        IRepository<T, TIdType> GetRepository<T, TIdType>
            () where TIdType : IComparable
            where T : BaseEntity<TIdType>;

        void Commit();
        void CommitAsync();
        void Rollback();
    }
}