using Fuel_Helper_API.Models;
using Fuel_Helper_API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Fuel_Helper_API.Controllers
{
    [ApiController]
    [Route("/queue/")]
    public class QueueInfoController : ControllerBase
    {
        private readonly QueueInfoRepository queueInfoRepository;

        public QueueInfoController(QueueInfoRepository queueInfoRepository)
        {
            this.queueInfoRepository = queueInfoRepository;
        }


        [HttpPost(Name = "addqueueinfo")]
        public IActionResult AddQueueInfo(QueueInfo queueInfo)
        {
            queueInfoRepository.addQueueInfoAsync(queueInfo);

            return Ok(queueInfo);

        }




    }
}
