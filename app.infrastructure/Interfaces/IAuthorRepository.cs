using System.Collections.Generic;
using System.Threading.Tasks;
using App.Core.Entities;

namespace App.Infrastructure.Interfaces
{
    public interface IAuthorRepository : IRepository<Author, int>
    {
        Task<Author> GetByName(string firstName);
        Task<IEnumerable<Author>> GetAuthorsDapper();
    }
}