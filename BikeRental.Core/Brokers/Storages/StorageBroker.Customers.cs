using BikeRental.Core.Models.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BikeRental.Core.Brokers.Storages;
public partial class StorageBroker
{
    public DbSet<Customer> Customers { get; set; }

    public async ValueTask<Customer> InsertCustomerAsync(Customer customer)
    {
        using var broker =
            new StorageBroker(this.configuration);

        EntityEntry<Customer> customerEntityEntry =
            await broker.Customers.AddAsync(customer);

        await broker.SaveChangesAsync();

        return customerEntityEntry.Entity;
    }

    public IQueryable<Customer> SelectAllCustomers()
    {
        using var broker =
            new StorageBroker(this.configuration);

        return broker.Customers;
    }

    public async ValueTask<Customer> SelectCustomerByIdAsync(int CustomerId)
    {
        using var broker =
            new StorageBroker(this.configuration);

        return await broker.Customers.FindAsync(CustomerId);
    }

    public async ValueTask<Customer> UpdateCustomerAsync(Customer customer)
    {
        using var broker =
            new StorageBroker(this.configuration);

        EntityEntry<Customer> customerEntityEntry =
            broker.Customers.Update(customer);

        await broker.SaveChangesAsync();

        return customerEntityEntry.Entity;
    }

    public async ValueTask<Customer> DeleteCustomerAsync(Customer customer)
    {
        using var broker =
            new StorageBroker(this.configuration);

        EntityEntry<Customer> customerEntityEntry =
            broker.Customers.Remove(customer);

        await broker.SaveChangesAsync();

        return customerEntityEntry.Entity;
    }
}

