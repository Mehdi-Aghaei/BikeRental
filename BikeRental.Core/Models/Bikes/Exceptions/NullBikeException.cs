using Xeptions;

namespace BikeRental.Core.Models.Bikes.Exceptions;
public class NullBikeException : Xeption
{
    public NullBikeException()
        : base(message: "bike is null.")
    { }
}
