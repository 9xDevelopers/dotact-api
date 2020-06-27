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
    public class Repository<T, IdType> : IRepository<T, IdType>
        where T : BaseEntity<IdType>
        where IdType : IComparable
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

        public T GetById(IdType id)
        {
            return entities.SingleOrDefault(s => s.Id.CompareTo(id) == 0);
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

        public void Delete(IdType id)
        {
            if (id == null) throw new ArgumentNullException("entity");


            var entity = entities.SingleOrDefault(s => s.Id.CompareTo(id) == 0);
            entities.Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<T> Search(Func<T, bool> conditions)
        {
            return entities.AsEnumerable().Where(conditions);
        }

        public Task<T> FindByCondition(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().FirstOrDefaultAsync(predicate);
        }
    }
}