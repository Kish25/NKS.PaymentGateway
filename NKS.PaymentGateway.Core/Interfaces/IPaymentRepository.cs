using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NKS.PaymentGateway.Core.Entities;

namespace NKS.PaymentGateway.Core.Interfaces
{
    public interface IPaymentRepository
    {
        void GetBy(Guid reference);
        void Create(Payment Payment);
    }
}
