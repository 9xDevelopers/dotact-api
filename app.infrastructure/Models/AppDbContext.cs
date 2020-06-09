using System;
using app.core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace app.infrastructure.Models
{
    public class AppDbContext:IdentityDbContext<AppUser,AppRole,Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            
        } 
        public DbSet<Author> authors { get; set; }
        public DbSet<Book> books { get; set; }  
    }
}