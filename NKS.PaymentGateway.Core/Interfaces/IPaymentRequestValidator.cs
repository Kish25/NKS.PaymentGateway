namespace NKS.Payments.Core.Interfaces
{
    using NKS.Payments.Core.Entities;
    /// <summary>
    /// Validates card details.
    /// </summary>
    public interface IPaymentRequestValidator
    {
        bool Validate(Payment payment);
    }
}