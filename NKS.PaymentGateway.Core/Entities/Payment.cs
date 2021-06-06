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

        public DateTime    BankSubmissionDate { get; init; }
        public CardDetails CardDetails        { get; init; }
        public string      Currency           { get; init; }
        public double      Amount             { get; init; }
        public int         UserId             { get; init; } // Just for some reference purpose
        public DateTime    BankProcessDate    { get; init; }
        public string      Status             { get; init; }
        public string      BankReference      { get; init; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }

    }
}
