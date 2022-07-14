using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeRental.Core.Brokers.Loggings;
using BikeRental.Core.Brokers.Storages;
using BikeRental.Core.Models.Customers;

namespace BikeRental.Core.Services.Foundations.Customers;
public class CustomerService : ICustomerService
{
    private readonly IStorageBroker storageBroker;
    private readonly ILoggingBroker loggingBroker;

    public CustomerService(IStorageBroker storageBroker, ILoggingBroker loggingBroker)
    {
        this.storageBroker = storageBroker;
        this.loggingBroker = loggingBroker;
    }

    public async ValueTask<Customer> AddCustomerAsync(Customer customer)
    {
        return await this.storageBroker.InsertCustomerAsync(customer);
    }
}
