using System;
using CreditCard.Inspector.Data.Entities;
using CreditCard.Inspector.Data.Repositories;
using Ninject;
using Ninject.Parameters;

namespace CreditCard.Inspector.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private CreditCardInspectorEntities _ctx;

        public UnitOfWork()
        {
            _ctx = new CreditCardInspectorEntities();
        }

        public T GetRepository<T>() where T : RepositoryBase
        {
            var kernel = new StandardKernel();
            var repository = kernel.Get<T>(new ConstructorArgument("ctx", _ctx));

            return (T) repository;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            _ctx.SaveChanges();
            _ctx.Dispose();
            _disposed = true;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}