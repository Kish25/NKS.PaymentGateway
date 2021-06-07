namespace NKS.PatmentGateway.IntegrationTests.API
{
    using System.Net;
    using Payments.API;
    using Payments.API.Contracts;
    using Payments.API.Controllers;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Payments.API.Interfaces;
    using Payments.Core.Entities;
    using Payments.Core.Interfaces;
    using Payments.Core.Services;
    using Payments.Infrastructure.Repositories;
    using Shouldly;
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

            var expectedResponse = new PaymentProcessResponse()
            {
                GatewayReference = "Fake_Reference",
                Status = "Success"
            };

            _paymentService.Setup(service => service.ProcessAsync(new PaymentRequest())).ReturnsAsync(new Payment());

            var apiResponse =  await _paymentsController.Post(request);

            apiResponse.ShouldBeOfType<OkObjectResult>();
        }
    }
}
