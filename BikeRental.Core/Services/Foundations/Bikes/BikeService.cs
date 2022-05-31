using BikeRental.Core.Brokers.Loggings;
using BikeRental.Core.Models.Bikes;

namespace BikeRental.Core.Services.Foundations.Bikes;
public class BikeService : IBikeService
{
    private readonly ILoggingBroker loggingBroker;

    public BikeService(ILoggingBroker loggingBroker)
    {
        this.loggingBroker = loggingBroker;
    }

    public ValueTask<Bike> AddBikeAsync(Bike bike)
    {
        throw new NotImplementedException();
    }
}
