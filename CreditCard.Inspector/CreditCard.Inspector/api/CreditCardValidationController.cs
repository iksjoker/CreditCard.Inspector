using System;
using System.Web.Http;

using CreditCard.Inspector.Services.Contracts;

namespace CreditCard.Inspector.api
{
    [RoutePrefix("api/card-validation")]
    public class CreditCardValidationController : ApiController
    {
        private ICreditCardService _creditCardService;

        public CreditCardValidationController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpPost, Route("")]
        public IHttpActionResult CheckCreditCard(Models.CreditCard card)
        {
            var result = _creditCardService.Execute(card);
            return Ok(result);
        }
    }
}