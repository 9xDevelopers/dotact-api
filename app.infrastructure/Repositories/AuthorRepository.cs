using System.Collections.Generic;
using System.Threading.Tasks;
using app.core.Entities;
using app.infrastructure.Interfaces;
using app.infrastructure.Models;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace app.infrastructure.Repositories
{
    public class AuthorRepository : Repository<Author, int>, IAuthorRepository
    {
        public AuthorRepository(AppDbContext context, IConfiguration config) : base(context, config)
        {
        }

        public Task<Author> GetByName(string name)
        {
            return FindByCondition(author => author.Name == name);
        }

        public async Task<IEnumerable<Author>> GetAuthorsDapper()
        {
            Task<IEnumerable<Author>> authors;
            using (var connection = Connection)
            {
                authors = connection.QueryAsync<Author>("select * from authors");
                return await authors;
            }
        }
    }
}