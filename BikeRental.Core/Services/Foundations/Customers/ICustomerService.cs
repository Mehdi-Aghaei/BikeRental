using BikeRental.Core.Models.Customers;

namespace BikeRental.Core.Services.Foundations.Customers;
public interface ICustomerService
{
    ValueTask<Customer> AddCustomerAsync(Customer customer);
}
