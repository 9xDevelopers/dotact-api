using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using app.core.Models;
using app.infrastructure.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace app.infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IConfiguration _config;
        protected readonly AppDbContext context;
        private readonly DbSet<T> entities;
        private string errorMessage = string.Empty;

        public Repository(AppDbContext context, IConfiguration config)
        {
            this.context = context;
            _config = config;
            entities = context.Set<T>();
        }

        public IDbConnection Connection => new SqlConnection(_config.GetConnectionString("DotactDBConnection"));

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T GetById(Guid id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public void Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            entities.Add(entity);
        }

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            if (id == null) throw new ArgumentNullException("entity");

            var entity = entities.SingleOrDefault(s => s.Id == id);
            entities.Remove(entity);
            context.SaveChanges();
        }

        public Task<T> FindByCondition(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().FirstOrDefaultAsync(predicate);
        }
    }
}