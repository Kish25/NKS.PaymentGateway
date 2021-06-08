using System;

namespace NKS.Payments.Core.Entities
{
    public class PaymentApiResponse
    {
        public string   Reference     { get; init; }
        public string   Status        { get; init; }
        public DateTime ProcessedDate { get; set; }
    }
}
