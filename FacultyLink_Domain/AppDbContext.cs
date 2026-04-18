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
        public DbSet<UserGroup> UserGroup { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Student> Student { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //user table
            modelBuilder.Entity<User>(dt =>
            {
                dt.Property(b => b.IsActive)
                .HasDefaultValue(true);
                dt.Property(b => b.CreatedDate)
                    .HasDefaultValue(DateTime.UtcNow);
                dt.Property(b => b.ModifiedDate)
                   .HasDefaultValue(DateTime.UtcNow);
            });

            modelBuilder.Entity<User>().HasData(
               new User
               {
                   Id = 1,
                   FirstName = "Godwin",
                   LastName = "Amadi",
                   Email = "amadigodwin7@gmail.com",
                   Password = "AQAAAAIAAYagAAAAEEGmmgarqr2Oz+FWWL9ahfrDc4gM2Nj5u9+LZk5XAeEUAmDjRRLEGcP3IbKVBf2GqQ==",
                   GroupId = 1,
               });



            modelBuilder.Entity<UserGroup>().HasData(
                new UserGroup
                {
                    GroupId = 1,
                    Name = "Admin",
                    Description = "Admin group with full access"
                },

                 new UserGroup
                 {
                     GroupId = 2,
                     Name = "Office_administrator",
                     Description = "Office Administrator"
                 },

                    new UserGroup
                    {
                        GroupId = 3,
                        Name = "Staff",
                        Description = "Academic and non-academic staff"
                    },
                new UserGroup
                {
                    GroupId = 4,
                    Name = "Student",
                    Description = "Student"
                },
                new UserGroup
                {
                    GroupId = 5,
                    Name = "HeadOfUnit",
                    Description = "Head of units. This group has administrative privileges " +
                    "over their respective units e.g department, faculty"
                }
            );

        }        
               
    }
}
