using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Core.Models;
using App.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App.Api.Controllers
{
    [Route("uow")]
    public class UoWConrtroller : ControllerBase
    {
        private readonly ILogger<UoWConrtroller> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UoWConrtroller(ILogger<UoWConrtroller> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("")]
        public Task<Author> CommitUoW()
        {
            var gambler = new Book("The Gambler");
            var fyodor = new Author("Fyodor Dostoyevsky", "Russia", new List<Book> {gambler});

            try
            {
                _unitOfWork.BookRepository.Insert(gambler);
                _unitOfWork.AuthorRepository.Insert(fyodor);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error when creating uow transaction, thereby reverting back. Error: {}", ex.Message);
                _unitOfWork.Rollback();
                return Task.FromResult(new Author());
            }

            return _unitOfWork.AuthorRepository.GetByName(fyodor.Name);
        }
    }
}