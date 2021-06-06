namespace NKS.Payments.Core.Interfaces
{
    using Entities;
    using System;

    public interface IPaymentRepository
    {
        Payment GetBy(string reference);
        void Create(Payment payment);
    }
}
