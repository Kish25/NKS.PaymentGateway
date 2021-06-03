using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NKS.Payments.Core.Entities;

namespace NKS.Payments.API.Interfaces
{
    public interface IPaymentService
    {
        Task<Payment> GetBy(Guid paymentReference);
        Task<Payment> ProcessAsync(PaymentRequest paymentRequest);
    }
}
