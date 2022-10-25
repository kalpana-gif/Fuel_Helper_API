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

        [HttpPut]
        [Route("updateexsistingqueue")]
        public async Task<IActionResult> UpdateQinfo(QueueInfo queueInfo)
        {
            try
            {
                var q = await queueInfoRepository.UpdatequeueInfo(queueInfo);
                return Ok(q);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }

        }


        [HttpDelete]
        [Route("deleteexsistingqueue")]
        public async Task<IActionResult> DeleteQinfo(QueueInfo queueInfo)
        {
            try
            {
                var station = await queueInfoRepository.DeleteExistingQ(queueInfo);
                return Ok(station);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
        [HttpGet]
        [Route("getqbyid")]
        public IActionResult GetRefillStationById(Guid id)
        {
            try
            {
                var q = queueInfoRepository.GetqById(id);

                if (q == null)
                {
                    return BadRequest("NOT FOUND");
                }
                return Ok(q);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }

        }





    }
 }
