using System;

namespace EFCore.HDelivery.Data.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}