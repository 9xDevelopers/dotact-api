using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using app.core.Entities;

namespace app.service.Interfaces
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