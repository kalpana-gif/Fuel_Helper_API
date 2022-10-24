using Fuel_Helper_API.Models;
using Fuel_Helper_API.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Fuel_Helper_API.Services
{
    public class ReFillStationService:ReFillStationRepository
    {

        private readonly IConfiguration _configuration;
     

        public ReFillStationService(IConfiguration configuration)
        {
            _configuration = configuration;
         
        }

     
        //add new satation
        public async Task addReFillStationAsync(ReFillStation refillstation)
        {

            MongoClient mongoClient = new MongoClient(_configuration.GetConnectionString("connection_strings"));
            await mongoClient.GetDatabase("FuelDB").GetCollection<ReFillStation>("ReFillStation").InsertOneAsync(refillstation);

        }

        //get all stations
        public List<ReFillStation> GetAllReFillStations()
        {
            MongoClient mongoClient = new MongoClient(_configuration.GetConnectionString("connection_strings"));
            var results = mongoClient.GetDatabase("FuelDB").GetCollection<ReFillStation>("ReFillStation").AsQueryable();
            List<ReFillStation> fuelStations = results.ToList();
            return fuelStations;
        }

        //get fuel station  by id
        public List<ReFillStation> GetRefillStationById(Guid refId)
        {
            MongoClient mongoClient = new MongoClient(_configuration.GetConnectionString("connection_strings"));
            var results = mongoClient.GetDatabase("FuelDB").GetCollection<ReFillStation>("ReFillStation").AsQueryable();
            List<ReFillStation> fuelStations = results.Where(x => x.Id == refId).ToList();
            return fuelStations;
        }

        public async Task<ReFillStation> UpdateRefillStation(ReFillStation fuelStation)
        {

            MongoClient mongoClient = new MongoClient(_configuration.GetConnectionString("connection_strings"));
            var filter = Builders<ReFillStation>.Filter.Eq("Id", fuelStation.Id);
            await mongoClient.GetDatabase("FuelDB").GetCollection<ReFillStation>("ReFillStation").ReplaceOneAsync(filter, fuelStation);

            return fuelStation;
        }
        public async Task<string> DeleteExistingReFillStation(ReFillStation fuelStation)
        {

            MongoClient mongoClient = new MongoClient(_configuration.GetConnectionString("connection_strings"));
            var filter = Builders<ReFillStation>.Filter.Eq("Id", fuelStation.Id);
            await mongoClient.GetDatabase("FuelManagementDb").GetCollection<ReFillStation>("ReFillStation").DeleteOneAsync(filter);

            return "Re-Fill Station has been Succeussfully Removed!!!";
        }


    }
}
