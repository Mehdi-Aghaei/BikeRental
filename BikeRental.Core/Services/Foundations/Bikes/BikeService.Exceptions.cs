using BikeRental.Core.Models.Bikes;
using BikeRental.Core.Models.Bikes.Exceptions;
using Xeptions;

namespace BikeRental.Core.Services.Foundations.Bikes;
public partial class BikeService
{
    private delegate ValueTask<Bike> ReturningBikeFunction();

    private async ValueTask<Bike> TryCatch(ReturningBikeFunction returningBikeFunction)
    {
        try
        {
            return await returningBikeFunction();

        }
        catch (NullBikeException nullBikeException)
        {

            throw CreateAndLogValidationException(nullBikeException);
        }
        catch (Exception exception)
        {
            var failedBikeServiceException =
                new FailedBikeServiceException(exception);

            throw CreateAndLogServiceException(failedBikeServiceException);
        }
    }

    private BikeValidationException CreateAndLogValidationException(Xeption exception)
    {
        var bikeValidationException =
            new BikeValidationException(exception);

        this.loggingBroker.LogError(bikeValidationException);

        return bikeValidationException;
    }

    private BikeServiceException CreateAndLogServiceException(Xeption exception)
    {
        var bikeServiceException =
            new BikeServiceException(exception);

        this.loggingBroker.LogError(bikeServiceException);

        return bikeServiceException;
    }
}
