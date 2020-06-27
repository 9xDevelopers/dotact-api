using System;
using app.core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace app.infrastructure.Models
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Plural to Singular Database Name
                modelBuilder.Entity(entityType.ClrType).ToTable(entityType.ClrType.Name);
            }
            base.OnModelCreating(modelBuilder);
            //Write Fluent API configurations here  
        }
    }
}