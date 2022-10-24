using Fuel_Helper_API.Models;
using Fuel_Helper_API.Repositories;
using MongoDB.Driver;

namespace Fuel_Helper_API.Services
{
    public class FuelStatusManagementService: FuelStatusManagementRepository
    {
        private readonly IConfiguration _configuration;

        public FuelStatusManagementService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task addFuelStatusInfoAsync(FuelStatusManagement fuelStatus)
        {

            MongoClient mongoClient = new MongoClient(_configuration.GetConnectionString("connection_strings"));
            await mongoClient.GetDatabase("FuelDB").GetCollection<FuelStatusManagement>("FuelStatus").InsertOneAsync(fuelStatus);

        }

    }
}
