using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;
namespace WorkingWithEFCore
{
    public class Northwind : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Northwind.db");
            optionsBuilder.UseLazyLoadingProxies().UseSqlite($"Filename={path}");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
            .Property(category => category.CategoryName).IsRequired() // NOT NULL 
            .HasMaxLength(15);
            // added to "fix" the lack of decimal support in SQLite 
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.Discontinued).Property(product => product.Cost).HasConversion<double>();
        }
    }
}