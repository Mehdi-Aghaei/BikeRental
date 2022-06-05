using BikeRental.Core.Brokers.Loggings;
using BikeRental.Core.Brokers.Storages;
using BikeRental.Core.Models.Bikes;

namespace BikeRental.Core.Services.Foundations.Bikes;
public class BikeService : IBikeService
{
    private readonly IStorageBroker storageBroker;
    private readonly ILoggingBroker loggingBroker;

    public BikeService(IStorageBroker storageBroker,ILoggingBroker loggingBroker )
    {
        this.storageBroker = storageBroker;
        this.loggingBroker = loggingBroker;
    }

    public async ValueTask<Bike> AddBikeAsync(Bike bike) =>
        await this.storageBroker.InsertBikeAsync(bike);
}
