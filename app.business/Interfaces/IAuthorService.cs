using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Core.Entities;

namespace App.Service.Interfaces
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