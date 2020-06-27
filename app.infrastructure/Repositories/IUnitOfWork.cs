using System;
using app.core.Models;

namespace app.infrastructure.Repositories
{
    public interface IUnitOfWork

    {
        IAuthorRepository AuthorRepository { get; }
        IBookRepository BookRepository { get; }

        IRepository<T, TIdType> GetRepository<T, TIdType>
            () where TIdType : IComparable
            where T : BaseEntity<TIdType>;

        void Commit();
        void Rollback();
    }
}