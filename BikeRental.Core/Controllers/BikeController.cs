using BikeRental.Core.Models.Bikes;
using BikeRental.Core.Models.Bikes.Exceptions;
using BikeRental.Core.Services.Foundations.Bikes;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace BikeRental.Core.Controllers;

[ApiController]
[Route("[controller]")]
public class BikeController : RESTFulController
{
    private readonly IBikeService bikeService;

    public BikeController(IBikeService bikeService)
    {
        this.bikeService = bikeService;
    }

    [HttpPost]
    public async ValueTask<ActionResult<Bike>> PostBikeAsync(Bike bike)
    {
        try
        {
            Bike addedBike =
                await this.bikeService.AddBikeAsync(bike);

            return Created(bike);
        }
        catch (BikeValidationException bikeValidationException)
        {

            return BadRequest(bikeValidationException.InnerException);
        }
        catch (BikeServiceException bikeServiceException)
        {
            return InternalServerError(bikeServiceException);
        }
    }
}
