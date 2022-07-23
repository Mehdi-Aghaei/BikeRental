using Xeptions;

namespace BikeRental.Core.Models.Bikes.Exceptions;
public class FailedBikeStorageException : Xeption
{
    public FailedBikeStorageException(Exception innerException)
        : base(message: "Failed bike storage error occurred, contact support.", innerException)
    { }
}
