namespace NKS.Payments.API.Contracts
{
    /// <summary>
    /// minimal contract defined to process payment request.
    /// </summary>
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
