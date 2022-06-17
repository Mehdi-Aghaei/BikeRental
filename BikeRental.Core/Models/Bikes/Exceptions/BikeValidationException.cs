using Xeptions;

namespace BikeRental.Core.Models.Bikes.Exceptions;
public class BikeValidationException : Xeption
{
    public BikeValidationException(Xeption innerException)
        : base(message: "Bike Validation errors occurred, please fix error and try again.", innerException)
    { }
}
