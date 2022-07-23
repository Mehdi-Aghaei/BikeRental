using System.Linq;
using BikeRental.Core.Models.Bikes;
using BikeRental.Core.Models.Bikes.Exceptions;
using FluentAssertions;
using Force.DeepCloner;
using Microsoft.Data.SqlClient;
using Moq;
using Xunit;

namespace BikeRental.Core.Tests.Unit.Services.Foundations.Bikes;
public partial class BikeServiceTests
{
    [Fact]
    public void ShouldThrowCriticalDependencyExceptionOnRetrieveAllIfSqlErrorOccursAndLogIt()
    {
        // given
        SqlException sqlException = GetSqlException();

        var failedBikeStorageException =
            new FailedBikeStorageException(sqlException);

        var expectedBikeDependencyException =
            new BikeDependencyException(failedBikeStorageException);

        this.storageBrokerMock.Setup(broker =>
            broker.SelectAllBikes())
                .Throws(sqlException);

        // when
        Action retrieveAllBikesAction = () => 
            this.bikeSevice.RetrieveAllBikes();

        BikeDependencyException actualBikeDependencyException =
               Assert.Throws<BikeDependencyException>(
                   retrieveAllBikesAction);
        // then
        actualBikeDependencyException.Should().BeEquivalentTo(expectedBikeDependencyException);

        this.storageBrokerMock.Verify(broker =>
            broker.SelectAllBikes(), 
                Times.Once);

        this.loggingBrokerMock.Verify(broker =>
            broker.LogCritical(It.Is(SameExceptionAs(
                expectedBikeDependencyException))),
                    Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
        this.loggingBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public void ShouldThrowServiceExceptionOnRetrieveAllIfServiceErrorOccursAndLogIt()
    {
        // given
        var exception = new Exception();

        var failedBikeServiceException =
            new FailedBikeServiceException(exception);

        var expectedBikeServiceException =
            new BikeServiceException(failedBikeServiceException);

        this.storageBrokerMock.Setup(broker =>
            broker.SelectAllBikes())
                .Throws(exception);

        // when
        Action retrieveAllBikesAction = () =>
            this.bikeSevice.RetrieveAllBikes();

        BikeServiceException actualBikeServiceException =
            Assert.Throws<BikeServiceException>(retrieveAllBikesAction);

        // then
        actualBikeServiceException.Should().BeEquivalentTo(expectedBikeServiceException);

        this.storageBrokerMock.Verify(broker =>
            broker.SelectAllBikes(), 
                Times.Once);

        this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(SameExceptionAs(
                expectedBikeServiceException))), 
                    Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
        this.loggingBrokerMock.VerifyNoOtherCalls();
    }
}

