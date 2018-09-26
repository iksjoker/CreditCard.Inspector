using System;
using System.Globalization;
using CreditCard.Inspector.Data;
using CreditCard.Inspector.Data.Repositories;
using CreditCard.Inspector.Models;
using CreditCard.Inspector.Services.Configuration;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace CreditCard.Inspector.Tests
{
    [TestFixture]
    public class ValidationTests: TestBase
    {
        [Test]
        public void Check_That_Expire_Date_Parsed_Correctly()
        {
            var expireDate = "122018";

            DateTime result;
            var date = $"{expireDate}";
            DateTime.TryParseExact(date, "MMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out result);

            Assert.IsInstanceOf(typeof(DateTime), result);
        }

        [Test]
        public void Check_That_UoW_Is_working()
        {
            using (var uow = EngineContext.Resolve<IUnitOfWork>())
            {
                var repository = uow.GetRepository<CreditCardRepository>();

                var result = repository.CheckThatCardExists(4563856219217000);
                Assert.IsTrue(result);
            }
        }

        [Test]
        public void Check_That_Visa_Is_Valid()
        {
            var creditCard = new Models.CreditCard();
            creditCard.CardNumber = 4563856219217000;
            creditCard.ExpireDate = "102020";
            var result = CreditCardService.Execute(creditCard);

            Assert.IsTrue(result.Result == ValidationType.Valid);
        }

        [Test]
        public void Check_That_Master_Card_Is_Valid()
        {
            var creditCard = new Models.CreditCard();
            creditCard.CardNumber = 5211874562849900;
            creditCard.ExpireDate = "102027";
            var result = CreditCardService.Execute(creditCard);

            Assert.IsTrue(result.Result == ValidationType.Valid);
        }

        [Test]
        public void Check_That_Amex_Is_Valid()
        {
            var creditCard = new Models.CreditCard();
            creditCard.CardNumber = 321895532647961;
            creditCard.ExpireDate = "102027";
            var result = CreditCardService.Execute(creditCard);

            Assert.IsTrue(result.Result == ValidationType.Valid);
        }

        [Test]
        public void Check_That_JCB_Is_Valid()
        {
            var creditCard = new Models.CreditCard();
            creditCard.CardNumber = 3128456123087742;
            creditCard.ExpireDate = "102027";
            var result = CreditCardService.Execute(creditCard);

            Assert.IsTrue(result.Result == ValidationType.Valid);
        }

        [Test]
        public void Check_That_Visa_Is_Invalid()
        {
            var creditCard = new Models.CreditCard();
            creditCard.CardNumber = 4563856219217000;
            creditCard.ExpireDate = "102019";
            var result = CreditCardService.Execute(creditCard);

            Assert.IsTrue(result.Result == ValidationType.Invalid);
        }

        [Test]
        public void Check_That_Master_Card_Is_Invalid()
        {
            var creditCard = new Models.CreditCard();
            creditCard.CardNumber = 5211874562849900;
            creditCard.ExpireDate = "102026";
            var result = CreditCardService.Execute(creditCard);

            Assert.IsTrue(result.Result == ValidationType.Invalid);
        }

        [Test]
        public void Check_That_Amex_Is_Invalid()
        {
            var creditCard = new Models.CreditCard();
            creditCard.CardNumber = 3218955326479617845;
            creditCard.ExpireDate = "102027";
            var result = CreditCardService.Execute(creditCard);

            Assert.IsTrue(result.Result == ValidationType.Invalid);
        }

        [Test]
        public void Check_That_JCB_Is_Invalid()
        {
            // No point to test it because JCB is always VALID
        }
    }
}