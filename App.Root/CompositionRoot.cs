using App.Infrastructure.Models;
using App.Infrastructure.Repositories;
using App.Service.Services.Implements;
using App.Service.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Root
{
    public class CompositionRoot
    {
        public static void injectDependencies(IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(config.GetConnectionString("DotactDBConnection")));

            services.AddScoped<AppDbContext>();

            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}