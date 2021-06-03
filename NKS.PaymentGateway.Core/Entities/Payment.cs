namespace NKS.Payments.Core.Entities
{
    using System;
    /// <summary>
    /// Core domain entity for payment processing.
    /// </summary>
    public class Payment : BaseEntity
    {
        public Payment()
        {
            
        }
        public Payment(Guid id) : base(id)
        {

        }

        public DateTime BankSubmissionDate { get; set; }
        public CardDetails CardDetails { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        // UserId: only for reference purpose, possibly Guid/email/customer login id and based auth of registered user/company.
        public int UserId { get; set; }     
        public DateTime BankProcessDate { get; set; }
        public PaymentStatus Status { get; set; }
        public string BankReference { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }

    }
}
