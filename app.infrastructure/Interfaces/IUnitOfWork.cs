using System;
using app.core.BaseEntities;
using app.core.Entities;

namespace app.infrastructure.Interfaces
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