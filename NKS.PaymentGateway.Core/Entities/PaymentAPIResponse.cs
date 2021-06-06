using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKS.Payments.Core.Entities
{
    public class PaymentAPIResponse
    {
        public string   Reference     { get; init; }
        public string   Status        { get; init; }
        public DateTime ProcessedDate { get; set; }
    }
}
