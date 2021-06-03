namespace NKS.Payments.API.Services
{
    using Contracts;
    using Interfaces;
    using Core.Entities;

    public class PaymentMapper : IPaymentMapper
    {
        public PaymentRequest ToDomainEntity(PaymentProcessRequest request)
        {
            return new PaymentRequest();
        }

        public PaymentDTO ToPaymentDetailsDto(Payment payment)
        {
            return new PaymentDTO();
        }

        public PaymentProcessResponse ToPaymentProcessResponse(Payment payment)
        {
            return new PaymentProcessResponse();
        }
    }
}
