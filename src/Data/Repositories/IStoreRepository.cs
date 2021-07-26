using System.Threading.Tasks;
using EFCore.HDelivery.Domain;

namespace EFCore.HDelivery.Data.Repositories
{
    public interface IStoreRepository
    {
        Task<Store> GetByIdAsync(int id);
        void Add(Store store);
        bool Save();
    }
}