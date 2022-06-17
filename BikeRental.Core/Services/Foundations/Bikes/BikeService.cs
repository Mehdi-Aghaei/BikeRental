using BikeRental.Core.Brokers.Loggings;
using BikeRental.Core.Brokers.Storages;
using BikeRental.Core.Models.Bikes;

namespace BikeRental.Core.Services.Foundations.Bikes;
public partial class BikeService : IBikeService
{
    private readonly IStorageBroker storageBroker;
    private readonly ILoggingBroker loggingBroker;

    public BikeService(IStorageBroker storageBroker, ILoggingBroker loggingBroker)
    {
        this.storageBroker = storageBroker;
        this.loggingBroker = loggingBroker;
    }

    public ValueTask<Bike> AddBikeAsync(Bike bike) =>
    TryCatch(async () =>
    {
        ValidateBikeIsNotNull(bike);

        return await this.storageBroker.InsertBikeAsync(bike);
    });
}
