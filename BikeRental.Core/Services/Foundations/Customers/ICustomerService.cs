using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeRental.Core.Models.Customers;

namespace BikeRental.Core.Services.Foundations.Customers;
public interface ICustomerService
{
    ValueTask<Customer> AddCustomerAsync(Customer customer);
}
