using Fuel_Helper_API.Repositories;
using Fuel_Helper_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<VehicleUserRepository, VehicleUserService>();
builder.Services.AddScoped<ReFillStationRepository, ReFillStationService>();
builder.Services.AddScoped<QueueInfoRepository, QueueInfoService>();
builder.Services.AddScoped<FuelStatusManagementRepository, FuelStatusManagementService>();

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
