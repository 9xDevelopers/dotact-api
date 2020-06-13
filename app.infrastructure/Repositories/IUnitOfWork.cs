using System;
using System.Collections;
using System.Collections.Generic;
using app.core.Models;
using Microsoft.EntityFrameworkCore;

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