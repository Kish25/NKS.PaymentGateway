using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NKS.Payments.Core.Entities;
using NKS.Payments.Core.Interfaces;

namespace NKS.Payments.Infrastructure.Repositories
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
