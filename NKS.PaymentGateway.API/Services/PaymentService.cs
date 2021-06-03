namespace NKS.Payments.API.Services
{
    using System;
    using System.Threading.Tasks;
    using Interfaces;
    using Core.Entities;
    using NKS.Payments.Core.Interfaces;
    /// <summary>
    /// Domain service to validate payment details and process.
    /// </summary>
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepositoryrepository;
        private readonly IPaymentRequestValidator _paymentRequestValidator;

        public PaymentService(IPaymentRequestValidator paymentRequestValidator, IPaymentRepository paymentRepositoryrepository)
        {
            _paymentRequestValidator = paymentRequestValidator;
            _paymentRepositoryrepository = paymentRepositoryrepository;
        }

        public async Task<Payment> GetBy(Guid paymentReference)
        {
            
            return new Payment(Guid.NewGuid());
        }

        public Task<Payment> ProcessAsync(PaymentRequest paymentRequest)
        {
            throw new NotImplementedException();
        }
    }
}
