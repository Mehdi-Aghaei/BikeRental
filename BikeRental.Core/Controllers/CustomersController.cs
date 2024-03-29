﻿using BikeRental.Core.Models.Customers;
using BikeRental.Core.Models.Customers.Exceptions;
using BikeRental.Core.Services.Foundations.Customers;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace BikeRental.Core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : RESTFulController
{
    private readonly ICustomerService customerService;

    public CustomersController(ICustomerService customerService)
    {
        this.customerService = customerService;
    }

    [HttpPost]
    public async ValueTask<ActionResult<Customer>> PostCustomerAsync(Customer customer)
    {
        try
        {
            Customer addedCustomer =
                await this.customerService.AddCustomerAsync(customer);

            return Created(customer);
        }
        catch (CustomerValidationExcetpion customerValidationException)
        {

            return BadRequest(customerValidationException.InnerException);
        }
        catch (CustomerServiceException customerServiceException)
        {
            return InternalServerError(customerServiceException);
        }
    }
}
