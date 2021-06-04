
namespace NKS.Payments.Core.Exceptions
{
    using System;

    public class CardValidationException : Exception
    {
        public CardValidationException(string message):base(message)
        {
            
        }
    }
}
