namespace NKS.PatmentGateway.IntegrationTests.API
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Payments.API.Contracts;
    using Payments.API.Controllers;
    using Payments.API.Interfaces;
    using Payments.Core.Entities;
    using Shouldly;
    using System.Threading.Tasks;
    using Xunit;

    public class PaymentsControllerShould
    {
        private readonly PaymentsController _paymentsController;
        private readonly Mock<IPaymentService> _paymentService;
        private readonly Mock<IPaymentMapper> _paymentMapper;

        public PaymentsControllerShould()
        {
            _paymentService = new Mock<IPaymentService>();
            _paymentMapper = new Mock<IPaymentMapper>();
            _paymentsController = new PaymentsController(_paymentService.Object,
                                                         _paymentMapper.Object);
        }

        [Fact]
        public async Task ReturnOkWithResponse()
        {
            var request = new PaymentProcessRequest()
            {
                CardHolderName = "Test Card",
                Currency = "GBP",
                Amount = 1234.10,
                CardNumber = "4111111111111111",
                ExpiryMonth = 12,
                ExpiryYear = 2023,
                Cvv = 123
            };
            var requestModel = new PaymentRequest()
            {
                Amount = request.Amount,
                Currency = request.Currency,
                CardDetails = new CardDetails()
                {
                    CardHolderName = request.CardHolderName,
                    CardNumber = request.CardNumber,
                    ExpiryMonth = request.ExpiryMonth,
                    ExpiryYear = request.ExpiryYear,
                    Cvv = request.Cvv
                }
            };
            var expectedPayment= new Payment()
            {
                Id = Guid.NewGuid(),
                Currency = request.Currency,
                Amount = request.Amount,
                BankProcessDate = DateTime.Now,
                BankReference = "Fake",
                Status = "Success",
                UserId = 1,
                CardDetails = new CardDetails()
                {
                    CardHolderName = request.CardHolderName,
                    CardNumber = request.CardNumber,
                    ExpiryMonth = request.ExpiryMonth,
                    ExpiryYear = request.ExpiryYear,
                }
            };
            var expectedResponse = new PaymentProcessResponse()
            {
                GatewayReference = "Fake_Reference",
                Status = "Success"
            };

            _paymentMapper.Setup(p => p.ToDomainEntity(request)).Returns(requestModel);

            _paymentService.Setup(service => service.ProcessAsync(requestModel)).ReturnsAsync(
             expectedPayment);

            var apiResponse =  await _paymentsController.Post(request);
            var resp = (PaymentProcessResponse) ((OkObjectResult) apiResponse).Value;

            apiResponse.ShouldBeOfType<OkObjectResult>();
        //    resp.ShouldBeEquivalentTo(expectedResponse);  // checking of return value.
        }
    }
}
