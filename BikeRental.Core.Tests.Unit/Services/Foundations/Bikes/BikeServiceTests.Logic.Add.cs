using BikeRental.Core.Models.Bikes;
using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Xunit;

namespace BikeRental.Core.Tests.Unit.Services.Foundations.Bikes;
public partial class BikeServiceTests
{
    [Fact]
    public async Task ShouldAddBikeAsync()
    {
        // given
        Bike randomBike = CreateRandomBike();
        Bike inputBike = randomBike;
        Bike storageBike = inputBike;
        Bike expectedBike = storageBike.DeepClone();

        this.storageBrokerMock.Setup(broker =>
            broker.InsertBikeAsync(inputBike))
            .ReturnsAsync(storageBike);

        // when
        Bike actualBike =
            await this.bikeSevice.AddBikeAsync(inputBike);

        // then
        actualBike.Should().BeEquivalentTo(storageBike);

        this.storageBrokerMock.Verify(broker =>
            broker.InsertBikeAsync(inputBike),
                Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
        this.loggingBrokerMock.VerifyNoOtherCalls();
    }
}

