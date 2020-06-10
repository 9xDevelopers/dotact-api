using app.core.Models;
using app.infrastructure.Models;
using Microsoft.Extensions.Configuration;

namespace app.infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _databaseContext;
        private IAuthorRepository _authorRepository;
        private IRepository<Book> _bookRepository;

        public UnitOfWork(AppDbContext databaseContext, IConfiguration config)
        {
            _databaseContext = databaseContext;
            _config = config;
        }

        public IAuthorRepository AuthorRepository
        {
            get { return _authorRepository = _authorRepository ?? new AuthorRepository(_databaseContext, _config); }
        }

        public IRepository<Book> BookRepository
        {
            get { return _bookRepository = _bookRepository ?? new Repository<Book>(_databaseContext, _config); }
        }

        public void Commit()
        {
            _databaseContext.SaveChanges();
        }

        public void Rollback()
        {
            _databaseContext.Dispose();
        }
    }
}