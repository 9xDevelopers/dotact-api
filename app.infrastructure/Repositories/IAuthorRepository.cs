using System.Threading.Tasks;
using app.infrastructure.Models;

namespace app.infrastructure.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<Author> GetByName(string firstName);
    }
}