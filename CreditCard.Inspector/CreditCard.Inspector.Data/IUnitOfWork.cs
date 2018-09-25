using System;

namespace CreditCard.Inspector.Data
{
    public interface IUnitOfWork : IDisposable
    {
        T GetRepository<T>() where T : class;
    }
}