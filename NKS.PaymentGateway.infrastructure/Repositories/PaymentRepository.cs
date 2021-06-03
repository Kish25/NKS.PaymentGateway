using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NKS.PaymentGateway.Core.Entities;
using NKS.PaymentGateway.Core.Interfaces;

namespace NKS.PaymentGateway.infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        public void Create(Payment Payment)
        {
            throw new NotImplementedException();
        }

        public void GetBy(Guid reference)
        {
            throw new NotImplementedException();
        }
    }
}
