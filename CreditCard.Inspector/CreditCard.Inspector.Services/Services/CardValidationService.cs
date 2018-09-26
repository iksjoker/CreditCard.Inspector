using System;
using System.Collections.Generic;
using System.Globalization;

using CreditCard.Inspector.Core;
using CreditCard.Inspector.Data;
using CreditCard.Inspector.Data.Repositories;
using CreditCard.Inspector.Models;
using CreditCard.Inspector.Services.Configuration;
using CreditCard.Inspector.Services.Contracts;

namespace CreditCard.Inspector.Services.Services
{
    public class CardValidationService : ServiceBase, ICardValidationService
    {
        private IDictionary<CreditCardType, Func<ValidationType>> _functions;
        private ulong _cardNumber;
        private string _textCardNumber;
        private string _expireDate;

        public CardValidationService()
        {
            _functions = new Dictionary<CreditCardType, Func<ValidationType>>()
            {
                { CreditCardType.Visa, VisaValidation },
                { CreditCardType.MasterCard, MasterCardValidation},
                { CreditCardType.Amex, AmexValidation },
                { CreditCardType.JCB, JCBValidation},
                { CreditCardType.Unknown, UnknownValidation }
            };
        }

        private DateTime? ConvertExpireDate()
        {
            if (DateTime.TryParseExact(_expireDate, "MMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var expireDate))
                return expireDate;

            return null;
        }

        private bool CardExistsInDataBase(ulong cardNumber)
        {
            using (var uow = EngineContext.Resolve<IUnitOfWork>())
            {
                var repository = uow.GetRepository<CreditCardRepository>();
                var result = repository.CheckThatCardExists(cardNumber);
                Log.Write($"Card number {cardNumber} exists in DB: {result}");

                return result;
            }
        }

        private ValidationType CommonValidation(int digits)
        {
            if (_textCardNumber.Length != digits)
                return ValidationType.Invalid;

            var result = CardExistsInDataBase(_cardNumber) ? ValidationType.Valid : ValidationType.DoesNotExist;
            return result;
        }

        private ValidationType VisaValidation()
        {
            if (_textCardNumber.Length != 16)
                return ValidationType.Invalid;

            var expireDate = ConvertExpireDate();
            if (expireDate == null)
                return ValidationType.Invalid;

            ValidationType result;
            if (DateTime.IsLeapYear(expireDate.Value.Year))
                result = ValidationType.Valid;

            result = CardExistsInDataBase(_cardNumber) ? ValidationType.Valid : ValidationType.DoesNotExist;
            return result;
        }

        private ValidationType MasterCardValidation()
        {
            if (_textCardNumber.Length != 16)
                return ValidationType.Invalid;

            var expireDate = ConvertExpireDate();
            if (expireDate == null)
                return ValidationType.Invalid;

            ValidationType result;
            if (expireDate.Value.Year.IsPrime())
                result = ValidationType.Valid;

            result = CardExistsInDataBase(_cardNumber) ? ValidationType.Valid : ValidationType.DoesNotExist;
            return result;
        }

        private ValidationType AmexValidation()
        {
            return CommonValidation(15);
        }

        private ValidationType JCBValidation()
        {
            return ValidationType.Valid;
        }

        private ValidationType UnknownValidation()
        {
            return CommonValidation(16);
        }

        public ValidationType CheckThatCardIsValid(string expireDate, ulong cardNumber, CreditCardType type)
        {
            _cardNumber = cardNumber;
            _textCardNumber = cardNumber.ToString();
            _expireDate = expireDate;

            if (!_functions.ContainsKey(type))
                throw new CreditCardInspectorException("Unregistered credit card type");

            var function = _functions[type];
            return function();
        }
    }
}