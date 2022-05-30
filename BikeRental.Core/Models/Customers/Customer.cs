using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BikeRental.Core.Models.Rentals;

namespace BikeRental.Core.Models.Customers;
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Gender Gender { get; set; }
    public DateTimeOffset Birthday { get; set; }
    public string Street { get; set; }
    public string House { get; set; }
    public string ZipCode { get; set; }
    public string Town { get; set; }
    
    [JsonIgnore]
    public IEnumerable<Rental> Rentals { get; set; }
}
