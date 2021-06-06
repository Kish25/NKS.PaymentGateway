using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKS.Payments.Core.Exceptions
{
    public class PaymentRequestValidationException : PaymentProcessException
    {
        public PaymentRequestValidationException(string message) : base(message)
        {
        }
    }
}
