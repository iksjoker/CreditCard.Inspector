using CreditCard.Inspector.Models;
using CreditCard.Inspector.Services.Contracts;

namespace CreditCard.Inspector.Services.Services
{
    public class CreditCardService : ICreditCardService
    {
        private ICardTypeDetector _cardTypeDetector;
        private ICardValidationService _validationService;

        public CreditCardService(ICardTypeDetector cardTypeDetector, ICardValidationService validationService)
        {
            _cardTypeDetector = cardTypeDetector;
            _validationService = validationService;
        }

        public ValidationResult Execute(Models.CreditCard card)
        {
            var result = new ValidationResult();
            result.CardType = _cardTypeDetector.GetTypeFromNumber(card.CardNumber.ToString());
            result.Result = _validationService.CheckThatCardIsValid(card.ExpireDate, card.CardNumber, result.CardType);

            return result;
        }
    }
}