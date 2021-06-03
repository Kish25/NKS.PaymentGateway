
using NKS.PaymentGateway.Core.Entities;

namespace NKS.PaymentGateway.Core.Interfaces
{
    public interface IPaymentRequestValidator
    {
        bool Validate(Payment payment);
    }
}