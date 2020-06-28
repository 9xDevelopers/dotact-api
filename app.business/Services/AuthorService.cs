using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using app.core.Entities;
using app.infrastructure.Interfaces;
using app.service.Interfaces;

namespace app.service.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _unitOfWork.GetRepository<Author, int>().GetAll();
        }

        public Task<Author> GetAuthorByName(string firstName)
        {
            return _unitOfWork.AuthorRepository.GetByName(firstName);
        }

        public Task<IEnumerable<Author>> GetAuthorsDapper()
        {
            return _unitOfWork.AuthorRepository.GetAuthorsDapper();
        }

        public void CreateAuthor(Author author)
        {
            _unitOfWork.AuthorRepository.Insert(author);
            _unitOfWork.Commit();
        }

        public IEnumerable<Author> Search(Func<Author, bool> conditions)
        {
            return _unitOfWork.GetRepository<Author, int>().Search(conditions);
        }
    }
}