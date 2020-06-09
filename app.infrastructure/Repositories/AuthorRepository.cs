using System.Threading.Tasks;
using app.infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace app.infrastructure.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(AppDbContext context) : base(context)
        {
        }

        public Task<Author> GetByName(string name)
        {
            return FindByCondition(author => author.Name == name);
        }
    }
}