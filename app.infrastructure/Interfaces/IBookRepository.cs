using App.Core.Entities;

namespace App.Infrastructure.Interfaces
{
    public interface IBookRepository : IRepository<Book, int>
    {
        public string GetAuthorName();
    }
}