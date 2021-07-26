using System.Threading.Tasks;
using EFCore.HDelivery.Domain;

namespace EFCore.HDelivery.Data.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        void Add(Product product);
        bool Save();
    }
}