using System.Collections.Generic;
using System.Threading.Tasks;
using App.Core.Models;

namespace App.Infrastructure.Repositories
{
    public interface IAuthorRepository : IRepository<Author, int>
    {
        Task<Author> GetByName(string firstName);
        Task<IEnumerable<Author>> GetAuthorsDapper();
    }
}