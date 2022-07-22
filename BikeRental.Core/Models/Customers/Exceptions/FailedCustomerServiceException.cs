using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xeptions;

namespace BikeRental.Core.Models.Customers.Exceptions;
public class FailedCustomerServiceException : Xeption
{
	public FailedCustomerServiceException(Exception innerException)
        :base("Failed customer service error occurred, contact support",innerException)
		{ }
}
