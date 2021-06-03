using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NKS.PaymentGateway.API.Contracts
{
    public class PaymentProcessRequest
    {
        //-- to paymentdetails
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
        public int CVV { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }

    }
}
