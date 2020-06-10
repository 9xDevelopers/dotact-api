using System.Collections.Generic;
using System.Threading.Tasks;
using app.core.Models;
using app.infrastructure.Repositories;

namespace app.business.Services
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
            return _unitOfWork.AuthorRepository.GetAll();
        }

        public Task<Author> GetAuthorByName(string firstName)
        {
            return _unitOfWork.AuthorRepository.GetByName(firstName);
        }

        public void CreateAuthor(Author author)
        {
            _unitOfWork.AuthorRepository.Insert(author);
            _unitOfWork.Commit();
        }
    }
}