using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Core.Models;

namespace App.Service.Services.Interfaces
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