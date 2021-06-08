namespace NKS.Payments.Core.Interfaces
{
    using System.Threading.Tasks;
    using Entities;

    public interface IPaymentsApi
    {
        Task<PaymentApiResponse> ProcessPaymentAsync(PaymentRequest request);
    }
}