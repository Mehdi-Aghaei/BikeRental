using BikeRental.Core.Models.Bikes;
using Microsoft.EntityFrameworkCore;

namespace BikeRental.Core.Brokers.Storages;
public partial class StorageBroker
{
    public DbSet<Bike> Bikes { get; set; }
}


