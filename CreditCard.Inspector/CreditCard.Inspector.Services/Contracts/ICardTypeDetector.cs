using System;

using CreditCard.Inspector.Models;

namespace CreditCard.Inspector.Services.Contracts
{
    public interface ICardTypeDetector
    {
        CreditCardType GetTypeFromNumber(string cardNumber);
    }
}