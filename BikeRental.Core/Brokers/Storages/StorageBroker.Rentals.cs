using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeRental.Core.Models.Rentals;
using Microsoft.EntityFrameworkCore;

namespace BikeRental.Core.Brokers.Storages;
public partial class StorageBroker
{
    public DbSet<Rental> Rentals { get; set; }
}
    
