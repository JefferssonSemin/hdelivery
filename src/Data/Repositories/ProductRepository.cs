using System.Threading.Tasks;
using EFCore.HDelivery.Data.Repositories.Base;
using EFCore.HDelivery.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCore.HDelivery.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationContext context) : base(context)
        {
        
        }
    }
}