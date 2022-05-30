using BikeRental.Core.Models.Bikes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BikeRental.Core.Brokers.Storages;
public partial class StorageBroker
{
    public DbSet<Bike> Bikes { get; set; }

    public async ValueTask<Bike> InsertBikeAsync(Bike bike)
    {
        using var broker =
            new StorageBroker(this.configuration);

        EntityEntry<Bike> bikeEntityEntry =
            await broker.Bikes.AddAsync(bike);

        await broker.SaveChangesAsync();

        return bikeEntityEntry.Entity;
    }
}


