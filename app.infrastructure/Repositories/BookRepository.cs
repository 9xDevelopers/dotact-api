using app.core.Models;
using app.infrastructure.Models;
using Microsoft.Extensions.Configuration;

namespace app.infrastructure.Repositories
{
    public class BookRepository:Repository<Book>,IBookRepository
    {
        public BookRepository(AppDbContext context, IConfiguration config) : base(context, config)
        {
        }

        public string GetAuthorName()
        {
            throw new System.NotImplementedException();
        }
    }
}