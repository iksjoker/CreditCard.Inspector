using System;
using CreditCard.Inspector.Data.Entities;

namespace CreditCard.Inspector.Data.Repositories
{
    public class CreditCardRepository : RepositoryBase
    {
        public CreditCardRepository(CreditCardInspectorEntities ctx) : base(ctx)
        {
        }

        public bool CheckThatCardExists(ulong cardNumber)
        {
            var recordExists = Ctx.checkIfCreditCardExists((long?) cardNumber);

            return recordExists == 1;
        }
    }
}