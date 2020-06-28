using System.Collections.Generic;
using System.Threading.Tasks;
using app.core.Entities;

namespace app.infrastructure.Interfaces
{
    public interface IAuthorRepository : IRepository<Author, int>
    {
        Task<Author> GetByName(string firstName);
        Task<IEnumerable<Author>> GetAuthorsDapper();
    }
}