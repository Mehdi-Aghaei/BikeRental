using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeRental.Core.Brokers.Loggings;
using BikeRental.Core.Brokers.Storages;
using BikeRental.Core.Models.Customers;
using BikeRental.Core.Services.Foundations.Customers;
using Moq;
using Tynamix.ObjectFiller;

namespace BikeRental.Core.Tests.Unit.Services.Foundations.Customers;
public partial class CustomerServiceTests
{
    private readonly Mock<IStorageBroker> storageBrokerMock;
    private readonly Mock<ILoggingBroker> loggingBrokerMock;
    private readonly ICustomerService customerService;

    public CustomerServiceTests()
    {
        this.storageBrokerMock = new Mock<IStorageBroker>();
        this.loggingBrokerMock = new Mock<ILoggingBroker>();
        this.customerService = new CustomerService(
            this.storageBrokerMock.Object,
            this.loggingBrokerMock.Object);
    }

    private static DateTimeOffset GetRandomDateTimeOffset() =>
       new DateTimeRange(earliestDate: new DateTime()).GetValue();

    private static Customer CreateRandomCustomer() =>
        CreateCustomerFiller(date: GetRandomDateTimeOffset()).Create();

    private static Filler<Customer> CreateCustomerFiller(DateTimeOffset date)
    {
        var filler = new Filler<Customer>();

        filler.Setup().OnType<DateTimeOffset>()
            .Use(date);

        return filler;
    }
}
