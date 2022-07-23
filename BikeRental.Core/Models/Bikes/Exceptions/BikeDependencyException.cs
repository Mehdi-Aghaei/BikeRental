using Xeptions;

namespace BikeRental.Core.Models.Bikes.Exceptions;
public class BikeDependencyException : Xeption
{
    public BikeDependencyException(Xeption innerException)
        : base(message: "Bike dependency error occurred, contact support.", innerException)
    { }
}
