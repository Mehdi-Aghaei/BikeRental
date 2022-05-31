using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeRental.Core.Models.Rentals;

namespace BikeRental.Core.Brokers.Storages;
public partial interface IStorageBroker
{
    ValueTask<Rental> InsertRentalAsync(Rental rental);
    IQueryable<Rental> SelectAllRentals();
    ValueTask<Rental> SelectRentalByIdAsync(int rentalId);
    ValueTask<Rental> UpdateRentalAsync(Rental rental);
    ValueTask<Rental> DeleteRentalAsync(Rental rental);
}
    
