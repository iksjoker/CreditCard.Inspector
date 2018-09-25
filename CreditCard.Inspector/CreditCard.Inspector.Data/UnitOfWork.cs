using System;
using CreditCard.Inspector.Data.Entities;

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

        public T GetRepository<T>() where T : class
        {
            object[] args = { "ctx", _ctx };

            var type = typeof(T);
            var repository = Activator.CreateInstance(type, args);
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