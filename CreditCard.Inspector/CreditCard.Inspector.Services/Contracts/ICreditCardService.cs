using System;
using CreditCard.Inspector.Models;

namespace CreditCard.Inspector.Services.Contracts
{
    public interface ICreditCardService
    {
        ValidationResult Execute(Models.CreditCard card);
    }
}