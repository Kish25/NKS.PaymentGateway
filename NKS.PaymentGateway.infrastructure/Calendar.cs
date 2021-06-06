namespace NKS.Payments.Infrastructure
{
    using System;
    public class Calendar : ICalendar
    {
        public DateTime UtcDateTimeNow()
        {
            return DateTime.UtcNow;
        }
    }
}
