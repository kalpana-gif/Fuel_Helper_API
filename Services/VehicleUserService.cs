using Fuel_Helper_API.Models;
using Fuel_Helper_API.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Fuel_Helper_API.Services
{
    public class VehicleUserService : VehicleUserRepository
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

        public List<VehicleUser> GetAllVehicalUsers()
        {

            MongoClient mongoClient = new MongoClient(_configuration.GetConnectionString("connection_strings"));
            var results = mongoClient.GetDatabase("FuelDB").GetCollection<VehicleUser>("User").AsQueryable();
            List<VehicleUser> users = results.ToList();
            return users;
        }
        public List<VehicleUser> GetVehicalUserById(Guid refId)
        {
            MongoClient mongoClient = new MongoClient(_configuration.GetConnectionString("connection_strings"));
            var results = mongoClient.GetDatabase("FuelDB").GetCollection<VehicleUser>("User").AsQueryable();
            List<VehicleUser> owner = results.Where(x => x.Id == refId).ToList();
            return owner;
        }

        public async Task<string> DeleteExsistingVehicalUser(VehicleUser user)
        {
            MongoClient mongoClient = new MongoClient(_configuration.GetConnectionString("connection_strings"));
            var filter = Builders<VehicleUser>.Filter.Eq("Id", user.Id);
            await mongoClient.GetDatabase("FuelDB").GetCollection<VehicleUser>("VehicalOwner").DeleteOneAsync(filter);

            return "Vehicle User  has been Succeussfully Removed";
        }


    }
}
