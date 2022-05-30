using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRental.Core.Models.Rentals;
public class Rental
{
    private DateTimeOffset end;
    public int Id { get; set; }
    [Required]
    public DateTimeOffset RentalStart { get; set; }
    public DateTimeOffset RentalEnd { get; set; }
    [Column(TypeName = "decimal(8, 2)")]
    public Decimal TotalCost { get; set; }
    public bool Paid { get; set; } = false;
}
