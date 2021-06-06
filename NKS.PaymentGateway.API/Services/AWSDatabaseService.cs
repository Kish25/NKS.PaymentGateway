namespace NKS.Payments.API.Services
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using Interfaces;
    using Amazon.DynamoDBv2;
    using Amazon.DynamoDBv2.DocumentModel;
    using Amazon.DynamoDBv2.Model;

    public class AWSDatabaseService : IAWSDatabaseService
    {
        private IAmazonDynamoDB _client;
        public AWSDatabaseService(IAmazonDynamoDB client)
        {
            _client = client;
        }
        public bool CreateDatabase(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task<DescribeTableResponse> CreatePaymentsTableAsync()
        {

            throw new NotImplementedException();

        }

        public bool AddDummyData()
        {
            throw new System.NotImplementedException();
        }
    }
}
