namespace NKS.Payments.API.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class InfoModel
    {
        public InfoModel()
        {
            Id = Guid.NewGuid().ToString();
            DateTime = System.DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
            DayOfWeek = Enum.GetName(typeof(DayOfWeek), System.DateTime.UtcNow.DayOfWeek);
        }

        public String Id        { get; init; }
        public String DateTime  { get; init; }
        public String DayOfWeek { get; init; }
    }
}

