using CaseProject.Entities.Concrete;
using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CaseProject.DataAccess.Concrete
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=dbCase;Trusted_Connection=True;");
        }

        public DbSet<History> Histories { get; set; }
        public DbSet<HistoryCategory> HistoryCategories { get; set; }
        public DbSet<Language> Languages { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Language>().HasData(
                    new Language
                    {
                        Id = 1,
                        Name = "Turkish",
                        ShortName = "TR"
                    },
                    new Language
                    {
                        Id = 2,
                        Name = "Italian",
                        ShortName = "IT"
                    }
                );
        }
    }
}
