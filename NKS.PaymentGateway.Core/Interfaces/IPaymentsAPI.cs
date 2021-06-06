namespace NKS.Payments.Core.Interfaces
{
    using System.Threading.Tasks;
    using Entities;

    public interface IPaymentsAPI
    {
        Task<PaymentAPIResponse> ProcessPaymentAsync(PaymentRequest request);

    }
}