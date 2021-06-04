namespace NKS.PatmentGateway.UnitTests.Core
{
    using System.Collections.Generic;
    using Payments.Core.Entities;
    using Payments.Core.Services;
    using Xunit;

    public class PaymentRequestsShould
    {
        [Fact]
        public void ReturnsTrueWhenDetailsAreCorrect()
        {
            // Arrange   
            var requestValidator = new PaymentRequestValidator();
            var request = GetPaymentDetails();

            // Act
            var result = requestValidator.Validate(request);
            // Assert

            Assert.True(result,"Payment details are valid.");
        }
        [Theory]
        [ClassData(typeof(PaymentRequestTestData))]
        public void ReturnsFalseWhenDetailsAreNotCorrect(PaymentRequest request, bool expected)
        {
            // Arrange   
            var requestValidator = new PaymentRequestValidator();
            //var request = GetPaymentDetails();

            // Act
            var result = requestValidator.Validate(request);
            
            // Assert
            Assert.False(result,"Payment information is not correct.");
        }

        private static PaymentRequest GetPaymentDetails()
        {
            return new PaymentRequest()
            {
                Amount=120,
                Currency="GBP",
                CardDetails = new CardDetails()
                {
                    CardHolderName = "N Test",
                    CardNumber = "411111111111111",
                    ExpiryMonth = 12,
                    ExpiryYear = 2021,
                    Cvv = 123
                }
            };
        }
        

    }


}
