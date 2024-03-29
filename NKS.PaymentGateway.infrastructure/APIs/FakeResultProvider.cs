﻿namespace NKS.Payments.Infrastructure.APIs
{
    using Core.Entities;
    using Microsoft.Extensions.Options;
    using System;

    public class FakeResultProvider: IFakeResultProvider
    {
        private readonly IOptions<CheckoutBankAPISetting> _apiConfiguration;

        public FakeResultProvider(IOptions<CheckoutBankAPISetting> apiConfiguration)
        {
            _apiConfiguration = apiConfiguration;
        }

        public PaymentAPIResponse ReturnSuccessResultAsync()
        {
            if (_apiConfiguration.Value.MakeRealApiCall)
                return null;

            return new PaymentAPIResponse
            {
                Reference = "P1Abx12aB1",
                Status = "Success",
                ProcessedDate = DateTime.UtcNow // change to clock
            };
        }
    }
}
