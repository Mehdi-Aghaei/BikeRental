using BikeRental.Core.Models.Bikes;
using BikeRental.Core.Models.Bikes.Exceptions;

namespace BikeRental.Core.Services.Foundations.Bikes;
public partial class BikeService
{
    private static void ValidateBikeIsNotNull(Bike bike)
    {
        if (bike is null)
        {
            throw new NullBikeException();
        }
    }

}
