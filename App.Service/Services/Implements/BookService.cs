using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Core.Models;
using App.Infrastructure.Repositories;
using App.Service.Services.Interfaces;

namespace App.Service.Services.Implements
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
            throw new NotImplementedException();
        }

        public void CreateBook(Book book)
        {
            _unitOfWork.BookRepository.Insert(book);
            _unitOfWork.Commit();
        }

        public void DeleteBook(Guid bookId)
        {
            throw new NotImplementedException();
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

        public Book GetBookById(int bookId)
        {
            return _unitOfWork.BookRepository.GetById(bookId);
        }

        public void DeleteBook(int bookId)
        {
            _unitOfWork.BookRepository.Delete(bookId);
            _unitOfWork.Commit();
        }
    }
}