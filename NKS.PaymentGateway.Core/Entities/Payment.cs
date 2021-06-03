using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKS.PaymentGateway.Core.Entities
{
    public class Payment : BaseEntity
    {
        public Payment(Guid id) : base(id)
        {

        }
        public DateTime BankSubmissionDate { get; set; }

        public string CardNumber { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
        public string Cardtype { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
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
