using Xeptions;

namespace BikeRental.Core.Models.Customers.Exceptions;
public class CustomerServiceException : Xeption
{
    public CustomerServiceException(Xeption innerException)
        : base("Service error occurred, contact support.", innerException)
    { }
}
