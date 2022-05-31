using BikeRental.Core.Models.Bikes;

namespace BikeRental.Core.Brokers.Storages;
public partial interface IStorageBroker
{
    ValueTask<Bike> InsertBikeAsync(Bike bike);
    IQueryable<Bike> SelectAllBikes();
    ValueTask<Bike> SelectBikeByIdAsync(int bikeId);
    ValueTask<Bike> UpdateBikeAsync(Bike bike);
    ValueTask<Bike> DeleteBikeAsync(Bike bike); 
}