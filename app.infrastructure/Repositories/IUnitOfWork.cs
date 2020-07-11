using System;
using App.Core.Models;

namespace App.Infrastructure.Repositories
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