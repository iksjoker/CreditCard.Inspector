using System;

namespace CreditCard.Inspector.Models
{
    public class ValidationResult
    {
        public ValidationType Result { get; set; }
        public CreditCardType CardType { get; set; }
    }
}