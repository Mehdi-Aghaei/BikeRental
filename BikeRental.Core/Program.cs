using BikeRental.Core.Brokers.Loggings;
using BikeRental.Core.Brokers.Storages;
using BikeRental.Core.Services.Foundations.Bikes;
using BikeRental.Core.Services.Foundations.Customers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLogging();

RegisterBrokers(builder);
builder.Services.AddTransient<IBikeService, BikeService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void RegisterBrokers(WebApplicationBuilder builder)
{
    builder.Services.AddDbContext<StorageBroker>();
    builder.Services.AddTransient<IStorageBroker, StorageBroker>();
    builder.Services.AddTransient<ILoggingBroker, LoggingBroker>();
}