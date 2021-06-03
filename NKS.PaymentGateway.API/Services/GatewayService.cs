using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NKS.PaymentGateway.API.Interfaces;
using NKS.PaymentGateway.Core.Entities;

namespace NKS.PaymentGateway.API.Services
{
    public class GatewayService : IGatewayService
    {
        public Task<Payment> GetBy(string reference)
        {
            throw new NotImplementedException();
        }

        public Task<Payment> ProcessAsync(PaymentRequest paymentRequest)
        {
            throw new NotImplementedException();
        }
    }
}
