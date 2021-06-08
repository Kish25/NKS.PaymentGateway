namespace NKS.Payments.Core.Exceptions
{
    public class PaymentRequestValidationException : PaymentProcessException
    {
        public PaymentRequestValidationException(string message) : base(message)
        {
        }
    }
}
