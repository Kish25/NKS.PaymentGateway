using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKS.Payments.Core.Entities
{
    public class AWSConfiguration
    {
        public string RegionEndPoint { get; set; }
        public string TableName { get; set; }
        public string AccessKey { get; set; }
        public AWSUser User { get; set; }
    }
    public class AWSUser
    {
        public string Name      { get; set; }
        public string AccessId  { get; set; }
        public string AccessKey { get; set; }
    }
}
