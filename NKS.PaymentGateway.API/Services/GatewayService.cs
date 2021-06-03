using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NKS.PaymentGateway.API.Interfaces;
using NKS.PaymentGateway.Core.Entities;
using NKS.PaymentGateway.Core.Interfaces;
using Serilog;

namespace NKS.PaymentGateway.API.Services
{
    public class GatewayService : IGatewayService
    {
        private readonly IPaymentRepository _paymentRepositoryrepository;
        private readonly IPaymentRequestValidator _paymentRequestValidator;

        public GatewayService(IPaymentRequestValidator paymentRequestValidator, IPaymentRepository paymentRepositoryrepository)
        {
            _paymentRequestValidator = paymentRequestValidator;
            _paymentRepositoryrepository = paymentRepositoryrepository;
        }

        public async Task<Payment> GetBy(string reference)
        {

        }

        public Task<Payment> ProcessAsync(PaymentRequest paymentRequest)
        {
            throw new NotImplementedException();
        }
    }
}
