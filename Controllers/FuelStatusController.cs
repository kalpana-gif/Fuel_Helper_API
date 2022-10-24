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




    }
}
