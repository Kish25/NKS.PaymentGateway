namespace NKS.Payments.Core.Interfaces
{
    using Entities;
    using System;

    public interface IPaymentRepository
    {
        void GetBy(Guid reference);
        void Create(Payment Payment);
    }
}
