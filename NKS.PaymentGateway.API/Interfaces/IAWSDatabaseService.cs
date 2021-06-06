namespace NKS.Payments.API.Interfaces
{
    using System.Threading.Tasks;
    using Amazon.DynamoDBv2.Model;

    public interface IAWSDatabaseService
    {
        bool CreateDatabase(string name);
        Task<DescribeTableResponse> CreatePaymentsTableAsync();
        bool AddDummyData();
    }
}
