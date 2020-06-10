using System.Threading.Tasks;
using app.core.Models;
using app.infrastructure.Models;

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