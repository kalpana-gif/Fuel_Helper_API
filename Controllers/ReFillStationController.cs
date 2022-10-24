using Fuel_Helper_API.Models;
using Fuel_Helper_API.Repositories;
using Fuel_Helper_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Reflection.Metadata;

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

   

        //add new station to system

        [HttpPost(Name = "addstation")]
        public IActionResult AddRefillStation(ReFillStation reFillStation)
        {
            refillstationrepository.addReFillStationAsync(reFillStation);

            return Ok(reFillStation);

        }


        //get all station in system
        [HttpGet]
        [Route("getallstations")]
        public IActionResult GetAllStations()
        {
            try
            {
                var fuelStations = refillstationrepository.GetAllReFillStations();

                if (fuelStations == null)
                {
                    return BadRequest("NOT FOUND");
                }
                return Ok(fuelStations);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("getstationbyid")]
        public IActionResult GetRefillStationById(Guid id)
        {
            try
            {
                var fuelStation = refillstationrepository.GetRefillStationById(id);

                if (fuelStation == null)
                {
                    return BadRequest("NOT FOUND");
                }
                return Ok(fuelStation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }

        }

        [HttpPut]
        [Route("updateexsistingstation")]
        public async Task<IActionResult> UpdateRefillStation(ReFillStation refillstaion)
        {
            try
            {
                var fuelstation = await refillstationrepository.UpdateRefillStation(refillstaion);
                return Ok(fuelstation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpDelete]
        [Route("deleteexsistingstation")]
        public async Task<IActionResult> DeleteRefillStation(ReFillStation fuelStation)
        {
            try
            {
                var station = await refillstationrepository.DeleteExistingReFillStation(fuelStation);
                return Ok(station);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

    }
}
