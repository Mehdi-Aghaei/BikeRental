using BikeRental.Core.Brokers.Loggings;
using BikeRental.Core.Brokers.Storages;
using BikeRental.Core.Models.Bikes;
using BikeRental.Core.Services.Foundations.Bikes;
using Moq;
using Tynamix.ObjectFiller;

namespace BikeRental.Core.Tests.Unit.Services.Foundations.Bikes;
public partial class BikeServiceTests
{
    private readonly Mock<IStorageBroker> storageBrokerMock;
    private readonly Mock<ILoggingBroker> loggingBrokerMock;
    private readonly IBikeService bikeSevice;
    
    public BikeServiceTests()
    {
        this.storageBrokerMock = new Mock<IStorageBroker>();
        this.loggingBrokerMock = new Mock<ILoggingBroker>();
        this.bikeSevice = new BikeService(
            this.storageBrokerMock.Object, 
            this.loggingBrokerMock.Object);
    }

    private static DateTimeOffset GetRandomDateTimeOffset() =>
        new DateTimeRange(earliestDate: new DateTime()).GetValue();

    private static Bike CreateRandomBike() =>
        CreateBikeFiller(date: GetRandomDateTimeOffset()).Create();

    private static Filler<Bike> CreateBikeFiller(DateTimeOffset date)
    {
        var filler = new Filler<Bike>();
        
        filler.Setup()
            .OnType<DateTimeOffset>()
            .Use(date);
        
        return filler;
    }
}
