using Microsoft.EntityFrameworkCore;
using UserManager.Models;

namespace UserManager.DataAccess
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }


        private string _dbPath { get; set; }

        public DataContext(string dbPath)
        {

            _dbPath = dbPath;

            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite($"Filename={_dbPath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Make Id Property to the primary key
            modelBuilder.Entity<User>().HasKey(p => p.Id);

            //Required text to be set.
            modelBuilder.Entity<User>()
                .Property(p => p.Age)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(p => p.Name)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(p => p.Address)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(p => p.Phone)
                .IsRequired();




        }
    }
}
