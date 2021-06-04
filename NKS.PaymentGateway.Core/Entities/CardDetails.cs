namespace NKS.Payments.Core.Entities
{
    public class CardDetails
    {
        public string CardHolderName { get; set; }
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
        public int Cvv { get; set; }
    }
}