namespace NKS.Payments.API.Services
{
    using Core.Entities;
    using Core.Exceptions;
    using Interfaces;
    using NKS.Payments.Core.Interfaces;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Domain service to validate payment details and process.
    /// </summary>
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IPaymentRequestValidator _paymentRequestValidator;
        private readonly IPaymentsApi _paymentsApi;

        public PaymentService(IPaymentRequestValidator paymentRequestValidator,
                              IPaymentRepository paymentRepository,
                              IPaymentsApi paymentsApi)
        {
            _paymentRequestValidator = paymentRequestValidator;
            _paymentRepository = paymentRepository;
            _paymentsApi = paymentsApi;
        }

        public async Task<Payment> GetBy(string paymentReference)
        {

            return _paymentRepository.GetBy(paymentReference);
        }

        public async Task<Payment> ProcessAsync(PaymentRequest request)
        {
            if (!_paymentRequestValidator.Validate(request))
                throw new PaymentRequestValidationException("Payment or card validation failed.");

            var apiResponse = await _paymentsApi.ProcessPaymentAsync(request);

            if (apiResponse == null)
                throw new PaymentProcessException("Payment request failed.");

            var processedPayment = GetPaymentDetails(request, apiResponse);
            _paymentRepository.Create(processedPayment);

            return processedPayment;
        }

        private Payment GetPaymentDetails(PaymentRequest request, PaymentApiResponse apiResponse)
        {
            
            return new Payment()
            {
                Id = Guid.NewGuid(),
                Currency = request.Currency,
                Amount = request.Amount,
                BankProcessDate = apiResponse.ProcessedDate,
                BankReference = apiResponse.Reference,
                Status = apiResponse.Status,
                UserId = 1,
                CardDetails = new CardDetails()
                {
                    CardHolderName = request.CardDetails.CardHolderName,
                    CardNumber = request.CardDetails.CardNumber,
                    ExpiryMonth = request.CardDetails.ExpiryMonth,
                    ExpiryYear = request.CardDetails.ExpiryYear,
                }
            };
        }
    }
}
