using BikeRental.Core.Models.Bikes;
using BikeRental.Core.Models.Bikes.Exceptions;
using BikeRental.Core.Services.Foundations.Bikes;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace BikeRental.Core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BikesController : RESTFulController
{
    private readonly IBikeService bikeService;

    public BikesController(IBikeService bikeService)
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

    [HttpGet]
    public ActionResult<IQueryable<Bike>> GetAllBikes()
    {
        try
        {
            IQueryable<Bike> retrievedBikes =
                this.bikeService.RetrieveAllBikes();

            return Ok(retrievedBikes);
        }
        catch (BikeDependencyException bikeDependencyException)
        {
            return InternalServerError(bikeDependencyException);
        }
        catch (BikeServiceException bikeServiceException)
        {
            return InternalServerError(bikeServiceException);
        }
    }
}
