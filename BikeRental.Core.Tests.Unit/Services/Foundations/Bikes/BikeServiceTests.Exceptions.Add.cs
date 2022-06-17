using BikeRental.Core.Models.Bikes;
using BikeRental.Core.Models.Bikes.Exceptions;
using Moq;
using Xunit;

namespace BikeRental.Core.Tests.Unit.Services.Foundations.Bikes;
public partial class BikeServiceTests
{
    [Fact]
    public async Task ShouldThrowServiceExceptionOnAddIfServiceErrorOccursAndLogItAsync()
    {
        // given
        Bike someBike = CreateRandomBike();
        Exception serviceException = new Exception();

        var failedBikeServiceException =
            new FailedBikeServiceException(serviceException);

        var expectedBikeServiceException =
            new BikeServiceException(failedBikeServiceException);

        this.storageBrokerMock.Setup(broker =>
            broker.InsertBikeAsync(someBike))
                .ThrowsAsync(serviceException);

        // when
        ValueTask<Bike> addBikeTask =
            this.bikeSevice.AddBikeAsync(someBike);

        // then
        await Assert.ThrowsAsync<BikeServiceException>(() => addBikeTask.AsTask());

        this.storageBrokerMock.Verify(broker =>
            broker.InsertBikeAsync(someBike),
                Times.Once);

        this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(
                SameExceptionAs(expectedBikeServiceException))),
                    Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
        this.loggingBrokerMock.VerifyNoOtherCalls();
    }
}

