using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKS.PaymentGateway.Core.Exceptions
{
    public class CardValidationException : Exception
    {
        public CardValidationException(string message):base(message)
        {
            
        }
    }
}
