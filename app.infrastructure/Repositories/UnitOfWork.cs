using app.infrastructure.Models;

namespace app.infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _databaseContext;
        private IAuthorRepository _authorRepository;
        private IRepository<Book> _bookRepository;

        public UnitOfWork(AppDbContext databaseContext)
        { _databaseContext = databaseContext; }

        public IAuthorRepository AuthorRepository
        {
            get { return _authorRepository = _authorRepository ?? new AuthorRepository(_databaseContext); }
        }

        public IRepository<Book> BookRepository
        {
            get { return _bookRepository = _bookRepository ?? new Repository<Book>(_databaseContext); }
        }

        public void Commit()
        { _databaseContext.SaveChanges(); }

        public void Rollback()
        { _databaseContext.Dispose(); }
    }
}