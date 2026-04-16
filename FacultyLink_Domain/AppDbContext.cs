using FacultyLinkDomain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FacultyLinkDomain
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {          
        }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(b => b.IsActive)
                .HasDefaultValue(true);
            modelBuilder.Entity<User>()
                .Property(b => b.CreatedDate)
                .HasDefaultValue(DateTime.UtcNow);
           
        }
    }
}
