using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKS.PaymentGateway.Core.Entities
{
    public class Payment : BaseEntity
    {
        public Payment()
        {
            
        }
        public DateTime ProcessedDate { get; set; }
        public string CustomerReference { get; set; }
        public string BinNumber { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
        public int CVV { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }
        public string BankStatus { get; set; }
        public string BankReference { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }

    }
}
