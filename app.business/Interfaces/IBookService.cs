using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Core.Entities;

namespace App.Service.Interfaces
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(Guid bookId);
        void CreateBook(Book book);
        void DeleteBook(Guid bookId);
        Task<Author> CreateSampleBookWithAuthor();
    }
}