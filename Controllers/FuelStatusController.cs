using Fuel_Helper_API.Models;
using Fuel_Helper_API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Fuel_Helper_API.Controllers
{
    [ApiController]
    [Route("/fuelstatus/")]
    public class FuelStatusController : ControllerBase
    {
        private readonly FuelStatusManagementRepository fuelStatusManagementRepository;

        public FuelStatusController(FuelStatusManagementRepository fuelStatusManagementRepository)
        {
            this.fuelStatusManagementRepository = fuelStatusManagementRepository;
        }

        [HttpPost(Name = "addfuelstatusinfo")]
        public IActionResult AddFuelStatusInfo(FuelStatusManagement fuelStatusManagement)
        {
            fuelStatusManagementRepository.addFuelStatusInfoAsync(fuelStatusManagement);

            return Ok(fuelStatusManagement);

        }

        [HttpPut]
        [Route("updatefulestatus")]
        public async Task<IActionResult> UpdateFuelStatsinfo(FuelStatusManagement fuelStatusManagement)
        {
            try
            {
                var fuelStatus = await fuelStatusManagementRepository.UpdateFuelStatus(fuelStatusManagement);
                return Ok(fuelStatus);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }

        }


        [HttpDelete]
        [Route("deletestatus")]
        public async Task<IActionResult> DeleteFuelStatusInfoinfo(FuelStatusManagement fuelStatusManagement)
        {
            try
            {
                var fuelStatus = await fuelStatusManagementRepository.DeleteExistingStatusInfo(fuelStatusManagement);
                return Ok(fuelStatus);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
        [HttpGet]
        [Route("getfstatsusbyid")]
        public IActionResult GetRefillStationById(Guid id)
        {
            try
            {
                var fuelStatus = fuelStatusManagementRepository.GetFuelStatusById(id);

                if (fuelStatus == null)
                {
                    return BadRequest("NOT FOUND");
                }
                return Ok(fuelStatus);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }

        }


    }
}
