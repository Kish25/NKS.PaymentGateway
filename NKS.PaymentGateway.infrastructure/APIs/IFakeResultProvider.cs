namespace NKS.Payments.Infrastructure.APIs
{
    using Core.Entities;

    public interface IFakeResultProvider
    {
        PaymentAPIResponse ReturnSuccessResultAsync();
    }
}