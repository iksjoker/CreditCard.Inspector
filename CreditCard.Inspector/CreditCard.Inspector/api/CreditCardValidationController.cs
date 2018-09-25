using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using CreditCard.Inspector.Models;

namespace CreditCard.Inspector.api
{
    [RoutePrefix("api/card-validation")]
    public class CreditCardValidationController : ApiController
    {
        [HttpGet, Route("")]
        public ValidationResult CheckCreditCard()
        {
            return new ValidationResult()
            {
                CardType = CreditCardType.MasterCard,
                Result = ValidationType.Valid
            };
        }
    }
}