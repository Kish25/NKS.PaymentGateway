
namespace NKS.Payments.Core.Exceptions
{
    using System;
    public class PaymentProcessException : Exception
    {
        public PaymentProcessException(string message) : base(message)
        {

        }
    }
}
