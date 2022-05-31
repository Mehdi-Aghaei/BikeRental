namespace BikeRental.Core.Brokers.DateTimes;

public class DateTimeBroker : IDateTimeBroker
{
    public DateTimeOffset GetCurrentDateTimeOffset() =>
        DateTimeOffset.UtcNow;
}
