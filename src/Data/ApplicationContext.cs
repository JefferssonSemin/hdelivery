using Microsoft.EntityFrameworkCore;
using src.Domain;

namespace str.Data
{
    public class ApplicationContext: DbContext
    {
      public DbSet<Store> Store { get; set; }
      public DbSet<Product> Products { get; set; }

      public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
      {
          
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
        modelBuilder.Entity<Store>().HasData(
          new Store {Id = 1, Name = "Brusque"},
          new Store {Id = 2, Name = "Joaçaba"},
          new Store {Id = 3, Name = "Curitibanos"}
        );

          modelBuilder.Entity<Product>().HasData(
          new Product {Id = 1, Description = "Pão de queijo"},
          new Product {Id = 2, Description = "Caputino"},
          new Product {Id = 3, Description = "Coxinha"}
        );
        
      }
    }
}