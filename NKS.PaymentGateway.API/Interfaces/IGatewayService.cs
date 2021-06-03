using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NKS.PaymentGateway.Core.Entities;

namespace NKS.PaymentGateway.API.Interfaces
{
    public interface IGatewayService
    {
        Task<Payment> GetBy(string reference);
        Task<Payment> ProcessAsync(PaymentRequest paymentRequest);
    }
}
