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
        public CardDetails CardDetails { get; set; }
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
