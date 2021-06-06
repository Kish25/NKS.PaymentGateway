namespace NKS.Payments.API.Contracts
{
    /// <summary>
    /// Minimal contract defined to process payment request.
    /// </summary>
    public class PaymentProcessRequest
    {
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
        public int Cvv { get; set; }
        public string Currency { get; set; }
        public double Amount { get; set; }

    }
}
