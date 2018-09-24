using System;

namespace CreditCard.Inspector.Core
{
    public class CreditCardInspectorException : Exception
    {
        public CreditCardInspectorException()
        { }

        public CreditCardInspectorException(string message): base(message)
        { }

        public CreditCardInspectorException(string message, Exception innerException): base(message, innerException)
        { }
    }
}