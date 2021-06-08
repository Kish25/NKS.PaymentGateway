namespace NKS.Payments.Core.Interfaces
{
    using Entities;

    public interface IPaymentRepository
    {
        Payment GetBy(string reference);
        void Create(Payment payment);
    }
}
