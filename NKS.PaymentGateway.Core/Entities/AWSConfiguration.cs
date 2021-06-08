namespace NKS.Payments.Core.Entities
{
    public class AwsConfiguration
    {
        public string RegionEndPoint { get; set; }
        public string TableName { get; set; }
        public string AccessKey { get; set; }
        public AwsUser User { get; set; }
    }
    public class AwsUser
    {
        public string Name      { get; set; }
        public string AccessId  { get; set; }
        public string AccessKey { get; set; }
    }
}
