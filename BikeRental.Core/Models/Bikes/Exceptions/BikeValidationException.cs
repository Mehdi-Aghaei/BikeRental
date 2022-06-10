using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xeptions;

namespace BikeRental.Core.Models.Bikes.Exceptions;
public class BikeValidationException : Xeption
{
    public BikeValidationException(Xeption innerException)
        : base(message: "Bike Validation errors occurred, please fix error and try again.",innerException)
    { }
}
