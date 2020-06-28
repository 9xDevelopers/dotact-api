using app.core.Entities;

namespace app.infrastructure.Interfaces
{
    public interface IBookRepository : IRepository<Book, int>
    {
        public string GetAuthorName();
    }
}