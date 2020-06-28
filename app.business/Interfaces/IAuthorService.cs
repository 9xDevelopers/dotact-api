using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using app.core.Entities;

namespace app.service.Interfaces
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAllAuthors();
        Task<Author> GetAuthorByName(string firstName);
        Task<IEnumerable<Author>> GetAuthorsDapper();
        void CreateAuthor(Author author);
        IEnumerable<Author> Search(Func<Author, bool> conditions);
    }
}