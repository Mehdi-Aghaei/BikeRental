﻿using BikeRental.Core.Models.Customers;
using BikeRental.Core.Models.Customers.Exceptions;
using Xeptions;

namespace BikeRental.Core.Services.Foundations.Customers;

public partial class CustomerService
{
    private delegate ValueTask<Customer> ReturningCustomerFunction();

    private async ValueTask<Customer> TryCatch(ReturningCustomerFunction returningCustomerFunction)
    {
        try
        {
            return await returningCustomerFunction();

        }
        catch (NullCustomerExcetpion nullCustomerException)
        {

            throw CreateAndLogValidationException(nullCustomerException);
        }
        catch (Exception exception)
        {
            var failedCustomerServiveException =
                new FailedCustomerServiceException(exception);

            throw CreateAndLogServiceException(failedCustomerServiveException);
        }
    }

    private CustomerValidationExcetpion CreateAndLogValidationException(Xeption exception)
    {
        var customerValidationException =
            new CustomerValidationExcetpion(exception);

        this.loggingBroker.LogError(customerValidationException);

        return customerValidationException;
    }

    private CustomerServiceException CreateAndLogServiceException(Xeption exception)
    {
        var customerServiceException =
            new CustomerServiceException(exception);

        this.loggingBroker.LogError(customerServiceException);

        return customerServiceException;
    }
}
