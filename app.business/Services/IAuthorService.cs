using System.Collections.Generic;
using System.Threading.Tasks;
using app.core.Models;
using app.infrastructure.Models;

namespace app.business.Services
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAllAuthors();
        Task<Author> GetAuthorByName(string firstName);
        void CreateAuthor(Author author);
    }
}