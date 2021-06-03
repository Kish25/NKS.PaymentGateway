using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NKS.PaymentGateway.API.Contracts
{
    public class PaymentDetailsDTO
    {
        // get reqiest res
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }  // last 4 digit of card
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
        public int CVV { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }

        // date processed 
        //status 
    }
}
