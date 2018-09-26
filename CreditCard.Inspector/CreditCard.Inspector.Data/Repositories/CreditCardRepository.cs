using System;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
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
            var cardNumberParam = new SqlParameter("@CardNumber", SqlDbType.BigInt)
            {
                Value = cardNumber
            };
            var query = Ctx.Database.SqlQuery<CARD_INFO>("checkIfCreditCardExists @CardNumber", cardNumberParam);
            
            return query.Any();
        }
    }
}