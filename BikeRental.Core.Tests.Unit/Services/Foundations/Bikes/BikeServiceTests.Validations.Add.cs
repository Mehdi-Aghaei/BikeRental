using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeRental.Core.Models.Bikes;
using BikeRental.Core.Models.Bikes.Exceptions;
using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Xunit;

namespace BikeRental.Core.Tests.Unit.Services.Foundations.Bikes;
public partial class BikeServiceTests
{
    [Fact]
    public async Task ShouldThrowValidationExceptionOnAddIfbikeIsNullAndLogItAsync()
    {
        // given
        Bike noBike = null;

        var nullBikeValidationException =
            new NullBikeException();

        var expectedBikeValidationException =
            new BikeValidationException(nullBikeValidationException);

        // when
        ValueTask<Bike> addBikeTask =
            this.bikeSevice.AddBikeAsync(noBike);

        // then
        await Assert.ThrowsAsync<BikeValidationException>(() => addBikeTask.AsTask());

        this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(SameExceptionAs(expectedBikeValidationException))),
                Times.Once);

        this.storageBrokerMock.Verify(broker =>
            broker.InsertBikeAsync(It.IsAny<Bike>()), 
                Times.Never);

        this.loggingBrokerMock.VerifyNoOtherCalls();
        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}

