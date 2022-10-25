using Fuel_Helper_API.Models;
using Fuel_Helper_API.Repositories;
using MongoDB.Driver;

namespace Fuel_Helper_API.Services
{
    public class QueueInfoService : QueueInfoRepository
    {
        private readonly IConfiguration _configuration;

        public QueueInfoService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

   

        public async Task addQueueInfoAsync(QueueInfo queueinfo)
        {

            MongoClient mongoClient = new MongoClient(_configuration.GetConnectionString("connection_strings"));
            await mongoClient.GetDatabase("FuelDB").GetCollection<QueueInfo>("QueueInfo").InsertOneAsync(queueinfo);

        }

        public async Task<QueueInfo> UpdatequeueInfo(QueueInfo queueinfo)
        {

            MongoClient mongoClient = new MongoClient(_configuration.GetConnectionString("connection_strings"));
            var filter = Builders<QueueInfo>.Filter.Eq("Id", queueinfo.Id);
            await mongoClient.GetDatabase("FuelDB").GetCollection<QueueInfo>("QueueInfo").ReplaceOneAsync(filter, queueinfo);

            return queueinfo;
        }

        public async Task<string> DeleteExistingQ(QueueInfo queueinfo)
        {

            MongoClient mongoClient = new MongoClient(_configuration.GetConnectionString("connection_strings"));
            var filter = Builders<QueueInfo>.Filter.Eq("Id", queueinfo.Id);
            await mongoClient.GetDatabase("FuelManagementDb").GetCollection<QueueInfo>("QueueInfo").DeleteOneAsync(filter);

            return "Fuel Queue is no longer available !!!";
        }

        public List<QueueInfo> GetqById(Guid refId)
        {
            MongoClient mongoClient = new MongoClient(_configuration.GetConnectionString("connection_strings"));
            var results = mongoClient.GetDatabase("FuelDB").GetCollection<QueueInfo>("QueueInfo").AsQueryable();
            List<QueueInfo> q = results.Where(x => x.Id == refId).ToList();
            return q;
        }


    }
}
