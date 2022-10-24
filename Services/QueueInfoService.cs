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
    }
}
