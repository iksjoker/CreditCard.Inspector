using System;

using CreditCard.Inspector.Core;
using CreditCard.Inspector.Models;
using CreditCard.Inspector.Services.Contracts;

namespace CreditCard.Inspector.Services.Services
{
    public class CardTypeDetector : ServiceBase, ICardTypeDetector
    {
        private CreditCardType GetCardType(CreditCardType type)
        {
            Log.Write($"Credit card type detected: {type}");
            return type;
        }

        public CreditCardType GetTypeFromNumber(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber))
                throw new CreditCardInspectorException("Invalid credit card number");

            Log.Write($"The number of credit card that type should be detected: {cardNumber}");

            var firstSymbol = cardNumber[0].ToString();
            var result = CreditCardType.Unknown;
            switch (firstSymbol)
            {
                case "4":
                    result = GetCardType(CreditCardType.Visa);
                    break;
                case "5":
                    result = GetCardType(CreditCardType.MasterCard);
                    break;
                case "3":
                    if (cardNumber.Length == 15)
                        result = GetCardType(CreditCardType.Amex);

                    if (cardNumber.Length == 16)
                        result = GetCardType(CreditCardType.JCB);
                    break;
                default:
                    result = GetCardType(CreditCardType.Unknown);
                    break;
            }

            return result;
        }
    }
}