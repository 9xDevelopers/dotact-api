using App.Core.Models;

namespace App.Infrastructure.Repositories
{
    public interface IBookRepository : IRepository<Book, int>
    {
        public string GetAuthorName();
    }
}