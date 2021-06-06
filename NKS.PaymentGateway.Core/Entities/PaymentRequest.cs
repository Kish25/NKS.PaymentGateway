namespace NKS.Payments.Core.Entities
{
    public class PaymentRequest
    {
        public CardDetails CardDetails { get; set; }
        public string Currency { get; set; }
        public double Amount { get; set; }
    }
}
