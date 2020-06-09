using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using app.business.Services;
using app.core.Models;
using app.infrastructure.Models;
using app.infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace app.api.Controllers
{

    [Route("author")]
    public class AuthorController : ControllerBase
    {
        private IAuthorService authorService;

        public AuthorController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        [HttpGet("")]
        public IEnumerable<Author> GetAllAuthors() =>
            authorService.GetAllAuthors();

        [HttpGet("{authorName}")]
        public Task<Author> GetAuthorByName(String authorName) =>
            authorService.GetAuthorByName(authorName);

        [HttpPost("")]
        [AllowAnonymous]
        public void AddAuthor([FromBody] Author author) =>
            authorService.CreateAuthor(author);
    }
}