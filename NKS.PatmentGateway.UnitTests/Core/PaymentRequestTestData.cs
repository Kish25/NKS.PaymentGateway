namespace NKS.PatmentGateway.UnitTests.Core
{
    using System.Collections.Generic;
    using Payments.Core.Entities;
    using System.Collections;

    public class PaymentRequestTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new PaymentRequest
                {
                    Amount = 0,
                    Currency = "GBP",
                    CardDetails = new CardDetails()
                    {
                        CardHolderName = "N Test",
                        CardNumber = "411111111111111",
                        ExpiryMonth = 12,
                        ExpiryYear = 2021,
                        Cvv = 123
                    }
                },
                false
            };
            yield return new object[]
            {
                new PaymentRequest
                {
                    Amount = 110,
                    Currency = "",
                    CardDetails = new CardDetails()
                    {
                        CardHolderName = "N Test",
                        CardNumber = "411111111111111",
                        ExpiryMonth = 12,
                        ExpiryYear = 2021,
                        Cvv = 123
                    }
                },
                false
            };
            yield return new object[]
            {
                new PaymentRequest
                {
                    Amount = 110,
                    Currency = "GBP",
                    CardDetails = new CardDetails()
                    {
                        CardHolderName = "",
                        CardNumber = "411111111111111",
                        ExpiryMonth = 12,
                        ExpiryYear = 2021,
                        Cvv = 123
                    }
                },
                false
            };
            yield return new object[]
            {
                new PaymentRequest
                {
                    Amount = 110,
                    Currency = "GBP",
                    CardDetails = new CardDetails()
                    {
                        CardHolderName = "N Test",
                        CardNumber = "411111111",
                        ExpiryMonth = 12,
                        ExpiryYear = 2021,
                        Cvv = 123
                    }
                },
                false
            };
            yield return new object[]
            {
                new PaymentRequest
                {
                    Amount = 110,
                    Currency = "GBP",
                    CardDetails = new CardDetails()
                    {
                        CardHolderName = "N Test",
                        CardNumber = "411111111111111",
                        ExpiryMonth = 1,
                        ExpiryYear = 2021,
                        Cvv = 123
                    }
                },
                false
            };
            yield return new object[]
            {
                new PaymentRequest
                {
                    Amount = 110,
                    Currency = "GBP",
                    CardDetails = new CardDetails()
                    {
                        CardHolderName = "N Test",
                        CardNumber = "411111111111111",
                        ExpiryMonth = 12,
                        ExpiryYear = 2020,
                        Cvv = 123
                    }
                },
                false
            };
            yield return new object[]
            {
                new PaymentRequest
                {
                    Amount = 110,
                    Currency = "GBP",
                    CardDetails = new CardDetails()
                    {
                        CardHolderName = "N Test",
                        CardNumber = "411111111111111",
                        ExpiryMonth = 12,
                        ExpiryYear = 2021,
                        Cvv = 12
                    }
                },
                false
            };

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
