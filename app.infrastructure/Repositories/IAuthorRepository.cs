using System.Collections.Generic;
using System.Threading.Tasks;
using app.core.Models;

namespace app.infrastructure.Repositories
{
    public interface IAuthorRepository : IRepository<Author,int>
    {
        Task<Author> GetByName(string firstName);
        Task<IEnumerable<Author>> GetAuthorsDapper();
    }
}