using Microsoft.EntityFrameworkCore;
using Persistence.Entity;
using Persistence.Helper;
using System.Reflection.Metadata;
using System.Security.Principal;

namespace Persistence
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Class> Classes { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
       : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(u =>
            {
                u.Property(d => d.DateOfBirth).HasColumnType("date");
            });
            modelBuilder.Entity<Class>()
             .Property(u => u.Name).IsUnicode();

            modelBuilder.Entity<Class>()
                .HasMany(e => e.Users)
                .WithOne(e => e.Classes)
                .HasForeignKey(e => e.ClassesId);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Address = "Address",
                    ClassesId = null,
                    DateOfBirth = DateTime.Now,
                    Email = "admin@gmail.com",
                    FirstName = "AdminName",
                    LastName = "AdminLastName",
                    Password = "111".HashPasword(),
                    PhoneNumber = "(555) 111-222",
                    Role = "admin",

                });
            for (int i = 1; i <= 5; i++)
            {
                modelBuilder.Entity<Class>().HasData(
                   new Class
                   {
                       Id = i,
                       Name = $"ClassName{i}",
                   });
            }

        }

    }
}
