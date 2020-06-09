using System;
using app.business.Services;
using app.infrastructure.Models;
using app.infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace app.root
{
    public class CompositionRoot
    {
        public CompositionRoot() { }

        public static void injectDependencies(IServiceCollection services,IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(config.GetConnectionString("DotactDBConnection")));
            
            services.AddScoped<AppDbContext>();
            
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
        }
    }
}