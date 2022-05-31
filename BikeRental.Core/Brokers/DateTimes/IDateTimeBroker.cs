namespace BikeRental.Core.Brokers.DateTimes;

public interface IDateTimeBroker
{
    DateTimeOffset GetCurrentDateTimeOffset();
}
