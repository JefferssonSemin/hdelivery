using EFCore.HDelivery.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCore.HDelivery.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Store> Stores { get; set; }
        public DbSet<Product> Products { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
    }
}