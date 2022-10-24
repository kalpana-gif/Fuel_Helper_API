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

        public async Task addReFillStationAsync(ReFillStation refillstation)
        {

            MongoClient mongoClient = new MongoClient(_configuration.GetConnectionString("connection_strings"));
            await mongoClient.GetDatabase("FuelDB").GetCollection<ReFillStation>("ReFillStation").InsertOneAsync(refillstation);

        }
    }
}
