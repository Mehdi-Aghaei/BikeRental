using Xeptions;

namespace BikeRental.Core.Models.Customers.Exceptions;
public class CustomerValidationExcetpion : Xeption
{
    public CustomerValidationExcetpion(Xeption innerException)
        : base("Customer validation error occurred, please fix the errors and try again.", innerException)
    { }
}
