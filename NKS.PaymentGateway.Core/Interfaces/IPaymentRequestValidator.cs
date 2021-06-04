namespace NKS.Payments.Core.Interfaces
{
    using Entities;

    /// <summary>
    ///     Validates card details.
    /// </summary>
    public interface IPaymentRequestValidator
    {
        bool Validate(PaymentRequest payment);
    }
}