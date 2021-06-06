namespace NKS.Payments.Infrastructure
{
    using System;

    public interface ICalendar
    {
        /// <summary>
        /// Returns current UTC date and time
        /// </summary>
        /// <returns></returns>
        DateTime UtcDateTimeNow();
    }
}