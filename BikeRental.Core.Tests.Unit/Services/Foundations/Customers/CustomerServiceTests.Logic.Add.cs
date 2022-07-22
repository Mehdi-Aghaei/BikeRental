using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeRental.Core.Models.Customers;
using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Xunit;

namespace BikeRental.Core.Tests.Unit.Services.Foundations.Customers;
public partial class CustomerServiceTests
{
    [Fact]
    public async Task ShouldAddCustomerAsync()
    {
        // given
        Customer randomCustomer = CreateRandomCustomer();
        Customer inputCustomer = randomCustomer;
        Customer storageCustomer = inputCustomer;
        Customer expectedCustomer = storageCustomer.DeepClone();

        this.storageBrokerMock.Setup(broker =>
            broker.InsertCustomerAsync(inputCustomer))
                .ReturnsAsync(storageCustomer);

        // when
        Customer actualCustomer =
            await this.customerService.AddCustomerAsync(inputCustomer);

        // then
        actualCustomer.Should().BeEquivalentTo(expectedCustomer);

        this.storageBrokerMock.Verify(broker =>
            broker.InsertCustomerAsync(inputCustomer),
                Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
        this.loggingBrokerMock.VerifyNoOtherCalls();
    }
}