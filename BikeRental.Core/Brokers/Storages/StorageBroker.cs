using Microsoft.EntityFrameworkCore;

namespace BikeRental.Core.Brokers.Storages;

public partial class StorageBroker : DbContext, IStorageBroker
{
    private readonly IConfiguration configuration;

    public StorageBroker(IConfiguration configuration)
    {
        this.configuration = configuration;
        this.Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = this.configuration
            .GetConnectionString(name: "DefaultConnection");

        optionsBuilder.UseSqlServer(connectionString);
    }
}
