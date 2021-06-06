namespace NKS.Payments.API.Services
{
    using Contracts;
    using Interfaces;
    using Core.Entities;

    public class PaymentMapper : IPaymentMapper
    {
        public PaymentRequest ToDomainEntity(PaymentProcessRequest request)
        {
            return new ()
            {
                Amount=request.Amount,
                Currency=request.Currency,
                CardDetails = new CardDetails()
                {
                    CardHolderName = request.CardHolderName,
                    CardNumber =request.CardNumber,
                    ExpiryMonth = request.ExpiryMonth,
                    ExpiryYear = request.ExpiryYear,
                    Cvv=request.Cvv
                }
            };
        }

        public PaymentDTO ToPaymentDetailsDto(Payment payment)
        {
            return new PaymentDTO()
            {
                CardHolderName = payment.CardDetails.CardHolderName,
                Currency = payment.Currency,
                Amount = payment.Amount,
                CardNumber = GetLastFourDigits(payment.CardDetails.CardNumber),
                BankProcessDate = payment.BankProcessDate,
                BankSubmissionDate = payment.BankSubmissionDate,
                Status = payment.Status,
                Reference = payment.Id.ToString()
            };
        }

        private static string GetLastFourDigits(string number)
        {
            return number.Substring(number.Length-4);
        }

        public PaymentProcessResponse ToPaymentProcessResponse(Payment payment)
        {
            return new PaymentProcessResponse()
            {
                GatewayReference=payment.Id.ToString(),
                Status = payment.Status.ToString()
            };
        }
    }
}
