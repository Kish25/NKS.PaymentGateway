namespace NKS.Payments.Infrastructure.APIs
{
    using Core.Entities;
    using Microsoft.Extensions.Options;
    using System;

    public class FakeResultProvider: IFakeResultProvider
    {
        private readonly IOptions<CheckoutBankApiSetting> _apiConfiguration;

        public FakeResultProvider(IOptions<CheckoutBankApiSetting> apiConfiguration)
        {
            _apiConfiguration = apiConfiguration;
        }

        public PaymentApiResponse ReturnSuccessResultAsync()
        {
            if (_apiConfiguration.Value.MakeRealApiCall)
                return null;

            return new PaymentApiResponse
            {
                Reference = "P1Abx12aB1",
                Status = "Success",
                ProcessedDate = DateTime.UtcNow // change to clock
            };
        }
    }
}
