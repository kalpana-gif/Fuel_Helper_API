using Fuel_Helper_API.Models;
using Fuel_Helper_API.Repositories;
using MongoDB.Driver;

namespace Fuel_Helper_API.Services
{
    public class VehicleUserService:VehicleUserRepository
    {
        private readonly IConfiguration _configuration;

        public VehicleUserService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task addUserAsync(VehicleUser user)
        {

            MongoClient mongoClient = new MongoClient(_configuration.GetConnectionString("connection_strings"));
            await mongoClient.GetDatabase("FuelDB").GetCollection<VehicleUser>("User").InsertOneAsync(user);

        }

    }
}
