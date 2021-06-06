namespace NKS.Payments.API.Controllers
{
    using Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Amazon;
    using Amazon.DynamoDBv2;
    using Amazon.S3;
    using Core.Entities;
    using Microsoft.Extensions.Options;

    /// <summary>
    /// 
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class AWSController : Controller
    {
        private readonly IAWSDatabaseService _awsDatabaseService;
        private readonly IOptions<AWSConfiguration> _aswOptions;
        private readonly IAmazonS3 _amazonS3;
        public AWSController(IAWSDatabaseService awsDatabaseService, IAmazonS3 amazonS3)
        {
            _awsDatabaseService = awsDatabaseService;
            _amazonS3 = amazonS3;
        }

       /// <summary>
        /// Drops and Creates table 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("tables")]
        public IActionResult CreateTable()
        {
            //Drop and create database, then create table.
            //_awsDatabaseService.CreateTable("PaymentsDB","Payments");
            //  var client = new AmazonEC2Client()

            
            var awsDb = new AmazonDynamoDBClient("keyId", "key",
                                                 new AmazonDynamoDBConfig { ServiceURL = "http://localhost:8000" });
            


            return Ok();
        }

    }
}
