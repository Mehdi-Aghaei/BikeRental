using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xeptions;

namespace BikeRental.Core.Models.Bikes.Exceptions;
public class NullBikeException : Xeption
{
    public NullBikeException()
        : base(message: "bike is null.")
    { }
}
