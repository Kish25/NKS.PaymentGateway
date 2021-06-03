namespace NKS.Payments.Core.Interfaces
{
    using NKS.Payments.Core.Entities;
    using System;

    public interface IPaymentRepository
    {
        void GetBy(Guid reference);
        void Create(Payment Payment);
    }
}
