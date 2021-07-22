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
    }
}