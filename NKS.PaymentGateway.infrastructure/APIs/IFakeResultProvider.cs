namespace NKS.Payments.Infrastructure.APIs
{
    using System.Threading.Tasks;
    using Core.Entities;

    public interface IFakeResultProvider
    {
        PaymentAPIResponse ReturnSuccessResultAsync();
    }
}