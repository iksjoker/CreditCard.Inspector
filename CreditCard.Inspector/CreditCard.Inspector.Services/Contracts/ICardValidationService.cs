using System;

using CreditCard.Inspector.Models;

namespace CreditCard.Inspector.Services.Contracts
{
    public interface ICardValidationService
    {
        ValidationType CheckThatCardIsValid(string expireDate, ulong cardNumber, CreditCardType type);
    }
}