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

