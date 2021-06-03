using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NKS.PaymentGateway.API.Contracts
{
    public class PaymentProcessResponse
    {
        public Guid GatewayReference { get; set; }
        public string Status { get; set; }
    }
}
