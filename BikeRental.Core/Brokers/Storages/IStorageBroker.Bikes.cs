using BikeRental.Core.Models.Bikes;

namespace BikeRental.Core.Brokers.Storages;
public partial interface IStorageBroker
{
    ValueTask<Bike> InsertBikeAsync(Bike bike);
}