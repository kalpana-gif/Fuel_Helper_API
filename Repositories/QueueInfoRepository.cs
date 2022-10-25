using Fuel_Helper_API.Models;

namespace Fuel_Helper_API.Repositories
{
    public interface QueueInfoRepository
    {
        Task addQueueInfoAsync(QueueInfo queueinfo);
        
        Task<QueueInfo> UpdatequeueInfo(QueueInfo queueinfo);

        Task<string> DeleteExistingQ(QueueInfo queueinfo);

        List<QueueInfo> GetqById(Guid refId);

    }
}
