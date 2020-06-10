using app.core.Models;

namespace app.infrastructure.Repositories
{
    public interface IBookRepository:IRepository<Book>
    {
        public string GetAuthorName();
    }
}