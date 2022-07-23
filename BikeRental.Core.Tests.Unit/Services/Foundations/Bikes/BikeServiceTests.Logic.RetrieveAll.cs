using System.Linq;
using BikeRental.Core.Models.Bikes;
using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Xunit;

namespace BikeRental.Core.Tests.Unit.Services.Foundations.Bikes;
public partial class BikeServiceTests
{
    [Fact]
    public void ShouldRetrieveAllBikes()
    {
        // given
        IQueryable<Bike> randomBikes = CreateRandomBikes();
        IQueryable<Bike> retrievedBikes = randomBikes;
        IQueryable<Bike> expectedBikes = retrievedBikes.DeepClone();

        this.storageBrokerMock.Setup(broker =>
            broker.SelectAllBikes())
                .Returns(retrievedBikes);

        // when
        IQueryable<Bike> actualBikes =
            this.bikeSevice.RetrieveAllBikes();

        // then
        actualBikes.Should().BeEquivalentTo(expectedBikes);

        this.storageBrokerMock.Verify(broker =>
            broker.SelectAllBikes(),
                Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
        this.loggingBrokerMock.VerifyNoOtherCalls();
    }
}

