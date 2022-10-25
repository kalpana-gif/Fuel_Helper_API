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

        public async Task<FuelStatusManagement> UpdateFuelStatus(FuelStatusManagement fuelStatus)
        {

            MongoClient mongoClient = new MongoClient(_configuration.GetConnectionString("connection_strings"));
            var filter = Builders<FuelStatusManagement>.Filter.Eq("Id", fuelStatus.Id);
            await mongoClient.GetDatabase("FuelDB").GetCollection<FuelStatusManagement>("FuelStatus").ReplaceOneAsync(filter, fuelStatus);

            return fuelStatus;
        }
        public async Task<string> DeleteExistingStatusInfo(FuelStatusManagement fuelStatus)
        {

            MongoClient mongoClient = new MongoClient(_configuration.GetConnectionString("connection_strings"));
            var filter = Builders<FuelStatusManagement>.Filter.Eq("Id", fuelStatus.Id);
            await mongoClient.GetDatabase("FuelManagementDb").GetCollection<FuelStatusManagement>("FuelStatus").DeleteOneAsync(filter);

            return "Fuel Status is no longer available !!!";
        }

        public List<FuelStatusManagement> GetFuelStatusById(Guid refId)
        {
            MongoClient mongoClient = new MongoClient(_configuration.GetConnectionString("connection_strings"));
            var results = mongoClient.GetDatabase("FuelDB").GetCollection<FuelStatusManagement>("FuelStatus").AsQueryable();
            List<FuelStatusManagement> q = results.Where(x => x.Id == refId).ToList();
            return q;
        }






    }
}
