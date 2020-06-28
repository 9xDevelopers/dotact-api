using System;
using App.Core.Entities;
using App.Infrastructure.Interfaces;
using App.Infrastructure.Models;
using Microsoft.Extensions.Configuration;

namespace App.Infrastructure.Repositories
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