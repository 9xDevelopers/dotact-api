using System.Collections.Generic;
using System.Threading.Tasks;
using app.business.Services;
using app.core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace app.api.Controllers
{
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService authorService;

        public AuthorsController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        [HttpGet("")]
        public IEnumerable<Author> GetAllAuthors()
        {
            return authorService.GetAllAuthors();
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