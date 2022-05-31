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

    public IQueryable<Bike> SelectAllBikes()
    {
        using var broker =
            new StorageBroker(this.configuration);
        
        return broker.Bikes;
    }
    
    public async ValueTask<Bike> SelectBikeByIdAsync(int bikeId)
    {
        using var broker =
            new StorageBroker(this.configuration);

        return await Bikes.FindAsync(bikeId);
    }

    public async ValueTask<Bike> UpdateBikeAsync(Bike bike)
    {
        using var broker =
            new StorageBroker(this.configuration);

        EntityEntry<Bike> bikeEntityEntry =
            broker.Bikes.Update(bike);

        await broker.SaveChangesAsync();

        return bikeEntityEntry.Entity;
    }

    public async ValueTask<Bike> DeleteBikeAsync(Bike bike)
    {
        using var broker =
            new StorageBroker(this.configuration);

        EntityEntry<Bike> bikeEntityEntry =
            broker.Bikes.Remove(bike);

        await broker.SaveChangesAsync();

        return bikeEntityEntry.Entity;
    }
}


