using Xeptions;

namespace BikeRental.Core.Models.Customers.Exceptions;
public class NullCustomerExcetpion : Xeption
{
    public NullCustomerExcetpion()
        : base("Customer is null")
    { }
}
