using BikeRental.Core.Models.Bikes;

namespace BikeRental.Core.Services.Foundations.Bikes;
public interface IBikeService
{
    ValueTask<Bike> AddBikeAsync(Bike bike);
}
