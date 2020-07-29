using System.Collections.Generic;
using System.Threading.Tasks;
using App.Core.Models;
using App.Service.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [ApiVersion("1.0")]
    public class AuthorsController : BaseController<Author>
    {
        private readonly IAuthorService authorService;

        public AuthorsController(IAuthorService authorService) : base()
        {
            this.authorService = authorService;
        }

        [HttpGet("")]
        public IEnumerable<Author> GetAllAuthors()
        {
            return authorService.GetAllAuthors();
        }

        [HttpGet("test-search")]
        public IEnumerable<Author> TestSearch()
        {
            return authorService.Search(a => a.Name == "xyz");
        }

        [HttpGet("dapper")]
        public Task<IEnumerable<Author>> GetAllAuthorsDapper()
        {
            return authorService.GetAuthorsDapper();
        }

        [HttpGet("{authorName}")]
        public Task<Author> GetAuthorByName(string authorName)
        {
            return authorService.GetAuthorByName(authorName);
        }

        [HttpPost("")]
        [AllowAnonymous]
        public void AddAuthor([FromBody] Author author)
        {
            authorService.CreateAuthor(author);
        }
    }
}