using app.infrastructure.Models;

namespace app.infrastructure.Repositories
{
    public interface IUnitOfWork
    {
        IAuthorRepository AuthorRepository { get; }
        IRepository<Book> BookRepository { get; }
        void Commit();
        void Rollback();
    }
}