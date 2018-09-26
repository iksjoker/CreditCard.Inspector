using System;
using CreditCard.Inspector.Data.Repositories;

namespace CreditCard.Inspector.Data
{
    public interface IUnitOfWork : IDisposable
    {
        T GetRepository<T>() where T : RepositoryBase;
    }
}