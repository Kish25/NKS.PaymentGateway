namespace NKS.Payments.API.Interfaces
{
    using Core.Entities;
    using System.Threading.Tasks;

    public interface IPaymentService
    {
        Task<Payment> GetBy(string paymentReference);
        Task<Payment> ProcessAsync(PaymentRequest paymentRequest);
    }
}
