
namespace NKS.Payments.API.Interfaces
{
    using Core.Entities;
    using System;
    using System.Threading.Tasks;

    public interface IPaymentService
    {
        Task<Payment> GetBy(Guid paymentReference);
        Task<Payment> ProcessAsync(PaymentRequest paymentRequest);
    }
}
