using CreditCard.Inspector.Data.Entities;

namespace CreditCard.Inspector.Data.Repositories
{
    public abstract class RepositoryBase
    {
        protected CreditCardInspectorEntities Ctx;

        protected RepositoryBase(CreditCardInspectorEntities ctx)
        {
            Ctx = ctx;
        }
    }
}