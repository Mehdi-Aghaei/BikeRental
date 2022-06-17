using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BikeRental.Core.Models.Bikes;
using BikeRental.Core.Models.Customers;

namespace BikeRental.Core.Models.Rentals;
public class Rental
{
    public int Id { get; set; }
    [Required]
    public DateTimeOffset RentalStart { get; set; }
    public DateTimeOffset RentalEnd { get; set; }
    [Column(TypeName = "decimal(8, 2)")]
    public Decimal TotalCost { get; set; }
    public bool Paid { get; set; } = false;
    public int BikeId { get; set; }
    public Bike Bike { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
}
