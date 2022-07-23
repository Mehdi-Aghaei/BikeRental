using BikeRental.Core.Brokers.Loggings;
using BikeRental.Core.Brokers.Storages;
using BikeRental.Core.Models.Customers;

namespace BikeRental.Core.Services.Foundations.Customers;
public partial class CustomerService : ICustomerService
{
    private readonly IStorageBroker storageBroker;
    private readonly ILoggingBroker loggingBroker;

    public CustomerService(IStorageBroker storageBroker, ILoggingBroker loggingBroker)
    {
        this.storageBroker = storageBroker;
        this.loggingBroker = loggingBroker;
    }

    public ValueTask<Customer> AddCustomerAsync(Customer customer) =>
    TryCatch(async () =>
    {
        ValidateCustomerIsNotNull(customer);

        return await this.storageBroker.InsertCustomerAsync(customer);
    });
}
