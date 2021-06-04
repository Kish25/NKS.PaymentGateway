namespace NKS.Payments.API.Interfaces
{
    using Contracts;
    using Core.Entities;

    /// <summary>
    /// Can be AutoMapper or something else. Have not much experience on it, so using basic mapping.
    /// </summary>
    public interface IPaymentMapper
    {
        PaymentRequest ToDomainEntity(PaymentProcessRequest request);

        PaymentDTO ToPaymentDetailsDto(Payment payment);
        PaymentProcessResponse ToPaymentProcessResponse(Payment payment);
    }
}