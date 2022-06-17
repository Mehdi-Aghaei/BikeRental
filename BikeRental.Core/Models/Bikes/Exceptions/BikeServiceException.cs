using Xeptions;

namespace BikeRental.Core.Models.Bikes.Exceptions;
public class BikeServiceException : Xeption
{
    public BikeServiceException(Xeption innerException)
        : base(message: "Bike service error occurred, contact support.", innerException)
    { }
}
