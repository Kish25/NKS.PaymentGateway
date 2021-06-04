namespace NKS.Payments.Core.Entities
{
    public class PaymentRequest
    {
        public CardDetails CardDetails { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
    }
}
