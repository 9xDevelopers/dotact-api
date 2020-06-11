using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using app.core.Models;
using app.infrastructure.Repositories;

namespace app.business.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _unitOfWork.BookRepository.GetAll();
        }

        public Book GetBookById(Guid bookId)
        {
            return _unitOfWork.BookRepository.GetById(bookId);
        }

        public void CreateBook(Book book)
        {
            _unitOfWork.BookRepository.Insert(book);
            _unitOfWork.Commit();
        }

        public void DeleteBook(Guid bookId)
        {
            _unitOfWork.BookRepository.Delete(bookId);
            _unitOfWork.Commit();
        }

        public Task<Author> CreateSampleBookWithAuthor()
        {
            var gambler = new Book("The Gambler");
            var fyodor = new Author("Fyodor Dostoyevsky", "Russia", new List<Book> {gambler});

            try
            {
                _unitOfWork.BookRepository.Insert(gambler);
                _unitOfWork.AuthorRepository.Insert(fyodor);
                _unitOfWork.Commit();
            }
            catch
            {
                _unitOfWork.Rollback();
                return Task.FromResult(new Author());
            }

            return _unitOfWork.AuthorRepository.GetByName(fyodor.Name);
        }
    }
}