using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKS.PaymentGateway.Core
{
    public enum ObjectState
    {
        Unchanged = 0,
        New = 1,
        Added = 2,
        Modified = 3,
        UnderReview = 4,
        Deleted = 5,
        ModifiedRequiresApproval = 6
    }
}
