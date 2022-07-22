using BikeRental.Core.Models.Customers;
using BikeRental.Core.Models.Customers.Exceptions;

namespace BikeRental.Core.Services.Foundations.Customers;

public partial class CustomerService
{
    private static void ValidateCustomerIsNotNull(Customer customer)
    {
        if (customer is null)
        {
            throw new NullCustomerExcetpion();
        }
    }
}
