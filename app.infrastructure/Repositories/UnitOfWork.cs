using System;
using App.Core.BaseEntities;
using App.Infrastructure.Interfaces;
using App.Infrastructure.Models;
using Microsoft.Extensions.Configuration;

namespace App.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork

    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _databaseContext;
        private IAuthorRepository _authorRepository;
        private IBookRepository _bookRepository;

        public UnitOfWork(AppDbContext databaseContext, IConfiguration config)
        {
            _databaseContext = databaseContext;
            _config = config;
        }

        public IRepository<T, TIdType> GetRepository<T, TIdType>
            () where TIdType : IComparable
            where T : BaseEntity<TIdType>
        {
            return new Repository<T, TIdType>(_databaseContext, _config);
        }


        public IAuthorRepository AuthorRepository
        {
            get { return _authorRepository ??= new AuthorRepository(_databaseContext, _config); }
        }

        public IBookRepository BookRepository
        {
            get { return _bookRepository ??= new BookRepository(_databaseContext, _config); }
        }

        public void Commit()
        {
            _databaseContext.SaveChanges();
        }

        public void CommitAsync()
        {
            _databaseContext.SaveChangesAsync();
        }

        public void Rollback()
        {
            _databaseContext.Dispose();
        }
    }
}