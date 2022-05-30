using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using BikeRental.Core.Models.Rentals;

namespace BikeRental.Core.Models.Bikes;
public class Bike
{
    public int Id { get; set; }
    [Required]
    [MaxLength(25)]
    public string Brand { get; set; }
    [Required]
    public Category Category { get; set; }
    [MaxLength(1000)]
    public string Notes { get; set; }
    [Column(TypeName = "decimal(8,2)")]
    public decimal FirstHour { get; set; }
    [Column(TypeName = "decimal(8,2)")]
    public decimal AdditionalHour { get; set; }
    public DateTimeOffset PruchaseDate { get; set; }
    public DateTimeOffset DateOfLastService { get; set; }

    [JsonIgnore]
    public IEnumerable<Rental> Rentals { get; set; }
}
