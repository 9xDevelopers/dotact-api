using System;
using app.core.Entities;
using app.infrastructure.Interfaces;
using app.infrastructure.Models;
using Microsoft.Extensions.Configuration;

namespace app.infrastructure.Repositories
{
    public class BookRepository : Repository<Book, int>, IBookRepository
    {
        public BookRepository(AppDbContext context, IConfiguration config) : base(context, config)
        {
        }

        public string GetAuthorName()
        {
            throw new NotImplementedException();
        }
    }
}