using BikeRental.Core.Models.Customers;
using BikeRental.Core.Models.Customers.Exceptions;
using Moq;
using Xunit;

namespace BikeRental.Core.Tests.Unit.Services.Foundations.Customers;
public partial class CustomerServiceTests
{
    [Fact]
    public async Task ShouldThrowValidationExceptionOnAddIfCustomerIsNullAndLogItAsync()
    {
        // given
        Customer noCustomer = null;

        var nullCustomerValidationException =
            new NullCustomerExcetpion();

        var expectedCustomerValidationException =
            new CustomerValidationExcetpion(nullCustomerValidationException);

        this.storageBrokerMock.Setup(broker =>
            broker.InsertCustomerAsync(noCustomer))
                .ThrowsAsync(nullCustomerValidationException);

        // when
        ValueTask<Customer> addCustomerTask =
            this.customerService.AddCustomerAsync(noCustomer);

        // then
        await Assert.ThrowsAsync<CustomerValidationExcetpion>(() =>
            addCustomerTask.AsTask());

        this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(SameExceptionAs(
                expectedCustomerValidationException))),
                    Times.Once);

        this.storageBrokerMock.Verify(broker =>
            broker.InsertCustomerAsync(It.IsAny<Customer>()),
                Times.Never);

        this.loggingBrokerMock.VerifyNoOtherCalls();
        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}