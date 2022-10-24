using Fuel_Helper_API.Models;
using Fuel_Helper_API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Fuel_Helper_API.Controllers
{
   //add refillig station to system 
    [ApiController]
    [Route("[controller]")]
    public class ReFillStationController : ControllerBase
    {
        private readonly ReFillStationRepository refillstationrepository;

        public ReFillStationController(ReFillStationRepository refillstationrepository)
        {
            this.refillstationrepository = refillstationrepository;
        }

        [HttpPost(Name = "addStation")]
        public IActionResult AddRefillStation(ReFillStation reFillStation)
        {
            refillstationrepository.addReFillStationAsync(reFillStation);

            return Ok(reFillStation);

        }
    }
}
