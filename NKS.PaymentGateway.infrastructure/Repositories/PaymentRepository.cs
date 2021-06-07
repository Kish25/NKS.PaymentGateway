
namespace NKS.Payments.Infrastructure.Repositories
{
    using Core.Entities;
    using Core.Interfaces;
    using System;
    using Amazon;
    using Amazon.DynamoDBv2;

    public class PaymentRepository : IPaymentRepository
    {
        private readonly AmazonDynamoDBClient _dynamoDbClient;
        public PaymentRepository()
        {
            var newRegion = RegionEndpoint.GetBySystemName("eu-west-2");

            _dynamoDbClient = new AmazonDynamoDBClient(newRegion);
        }
        public void Create(Payment payment)
        {
            if (payment == null)
                throw new ArgumentNullException();

        }

        public Payment GetBy(string reference)
        {
            return new Payment()
            {
                Id = Guid.NewGuid(),
                Currency = "GBP",
                Amount = 1240.10,
                BankProcessDate = DateTime.Now,
                BankReference = "Fake_referene",
                BankSubmissionDate = DateTime.Now,
                Status = "Success",
                UserId = 1,
                CardDetails = new CardDetails()
                {
                    CardHolderName = "test",
                    CardNumber = "4111111111111111",
                    ExpiryMonth = 12,
                    ExpiryYear = 2023,
                }
            };
        }
    }
}
