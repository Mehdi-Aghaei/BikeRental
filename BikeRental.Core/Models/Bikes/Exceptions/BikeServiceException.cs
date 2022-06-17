using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xeptions;

namespace BikeRental.Core.Models.Bikes.Exceptions;
public class BikeServiceException : Xeption
{
	public BikeServiceException(Xeption innerException)
		: base(message: "Bike service error occurred, contact support.", innerException)
	{ }
}
