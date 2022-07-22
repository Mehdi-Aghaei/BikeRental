﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeRental.Core.Models.Customers;
using BikeRental.Core.Models.Customers.Exceptions;
using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Xunit;

namespace BikeRental.Core.Tests.Unit.Services.Foundations.Customers;
public partial class CustomerServiceTests
{
    [Fact]
    public async Task ShoukldThrowServiceExceptionOnAddIfServiceErrorOccursAndLogItAsync()
    {
        // given
        Customer someCustomer = CreateRandomCustomer();
        var serviceException = new Exception();

        var failedCustomerServiceException =
            new FailedCustomerServiceException(serviceException);

        var expectedCustomerServiceException =
            new CustomerServiceException(failedCustomerServiceException);

        this.storageBrokerMock.Setup(broker =>
            broker.InsertCustomerAsync(someCustomer))
                .ThrowsAsync(serviceException);
        
        // when
        ValueTask<Customer> addCustoemrTask =
            this.customerService.AddCustomerAsync(someCustomer);

        // then
        await Assert.ThrowsAsync<CustomerServiceException>(() => 
            addCustoemrTask.AsTask());

        this.storageBrokerMock.Verify(broker =>
            broker.InsertCustomerAsync(It.IsAny<Customer>()), 
                Times.Once);

        this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(SameExceptionAs(
                expectedCustomerServiceException))),
                    Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
        this.loggingBrokerMock.VerifyNoOtherCalls();
    }
}