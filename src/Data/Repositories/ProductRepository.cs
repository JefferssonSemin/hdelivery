using System.Threading.Tasks;
using EFCore.HDelivery.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCore.HDelivery.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;

        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Task<Product> GetByIdAsync(int id)
        {
            return _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}