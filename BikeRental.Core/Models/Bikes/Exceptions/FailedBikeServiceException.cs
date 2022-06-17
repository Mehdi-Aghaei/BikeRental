using Xeptions;

namespace BikeRental.Core.Models.Bikes.Exceptions;
public class FailedBikeServiceException : Xeption
{
    public FailedBikeServiceException(Exception innerException)
        : base(message: "Failed bike service error occurred, contact support.", innerException)
    { }
}
