using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKS.Payments.Core.Entities
{
    public class PaymentRequest
    {
        public CardDetails CardDetails { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
    }
}
