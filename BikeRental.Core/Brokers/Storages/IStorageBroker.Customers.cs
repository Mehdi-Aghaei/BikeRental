
using BikeRental.Core.Models.Customers;

namespace BikeRental.Core.Brokers.Storages;
public partial interface IStorageBroker
{
    ValueTask<Customer> InsertCustomerAsync(Customer customer);
    IQueryable<Customer> SelectAllCustomers();
    ValueTask<Customer> SelectCustomerByIdAsync(int CustomerId);
    ValueTask<Customer> UpdateCustomerAsync(Customer customer);
    ValueTask<Customer> DeleteCustomerAsync(Customer customer);
}