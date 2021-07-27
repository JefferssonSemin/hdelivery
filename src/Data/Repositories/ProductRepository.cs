using System.Threading.Tasks;
using EFCore.HDelivery.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCore.HDelivery.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<Product> _dbSet;

        public ProductRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<Product>();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            return _dbSet.FirstOrDefaultAsync(p => p.Id == id);
        }

        public void Add(Product product)
        {
            _dbSet.Add(product);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}