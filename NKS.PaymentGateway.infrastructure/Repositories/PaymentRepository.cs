// https: //docs.aws.amazon.com/sdk-for-net/v3/developer-guide/net-dg-config-creds.html#creds-locate
namespace NKS.Payments.Infrastructure.Repositories
{
    using Core.Entities;
    using Core.Interfaces;
    using System;
    using Amazon;
    using Amazon.DynamoDBv2;
    using Amazon.Runtime;
    using Amazon.Runtime.CredentialManagement;

    public class PaymentRepository : IPaymentRepository
    {
        private readonly AmazonDynamoDBClient _dynamoDbClient;
        private readonly IAmazonDynamoDB _dynamoDb;
        public PaymentRepository(IAmazonDynamoDB dynamoDb)
        {
            _dynamoDb = dynamoDb;
            var newRegion = RegionEndpoint.GetBySystemName("eu-west-2");
            var chain = new CredentialProfileStoreChain();
            AWSCredentials awsCredentials;
            if (chain.TryGetAWSCredentials("basic_profile", out awsCredentials))
            {
                // use awsCredentials
            }
            _dynamoDbClient = new AmazonDynamoDBClient(awsCredentials);

            
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
