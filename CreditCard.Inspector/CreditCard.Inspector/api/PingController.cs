using System;
using System.Web.Http;

using CreditCard.Inspector.Core;
using CreditCard.Inspector.Services.Contracts;

namespace CreditCard.Inspector.api
{
    [RoutePrefix("api/ping")]
    public class PingController : ApiController
    {
        private readonly ILog _log;
        private readonly IPingService _pingService;

        public PingController(IPingService pingService, ILog log)
        {
            _log = log;
            _pingService = pingService;
        }

        [HttpGet, Route("")]
        public IHttpActionResult GetTextValue()
        {
            _log.Write("Method to check that app is still alive.");
            return Ok(_pingService.GetValue());
        }
    }
}