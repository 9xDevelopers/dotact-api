using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using app.business.Services;
using app.core.Models;
using Moq;
using Xunit;

namespace app.test.Services
{
    public class AuthorServiceUnitTest
    {
        [Fact]
        public void Test_Invalid_Date()
        {
            Book book = new Book("Funny");
            var author = new Author("Hien", "None", new List<Book>() {book});
            IEnumerable<Author> authorsFake = new List<Author>()
            {
              author
            };
            var authorService = new Mock<IAuthorService>();
            authorService.Object.CreateAuthor(author);
            var bookService = new Mock<IBookService>();
            var authors = authorService.Object.GetAllAuthors();
            var authorSetup = authorService.Setup(a => a.GetAllAuthors()).Returns(authorsFake);

            var value = bookService.Object.GetAllBooks().FirstOrDefault().Author.Name;
            Assert.Equal("Hien", value);
        }
    }
}