using Fuel_Helper_API.Models;
using Fuel_Helper_API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace Fuel_Helper_API.Controllers
{
    //add vehicle user  to system 
    [ApiController]
    [Route("[controller]")]
    public class VehicleUserController : ControllerBase
    {
        private readonly VehicleUserRepository userRepository;

        public VehicleUserController(VehicleUserRepository userRepository)
        {
            this.userRepository = userRepository;
        
        }

        [HttpPost(Name = "addVehicleUser")]
        public IActionResult AddUser(VehicleUser vehicleUser)
        {
            userRepository.addUserAsync(vehicleUser);

            return Ok(vehicleUser);

        }

        [HttpGet]
        [Route("getallvehicleowners")]
        public IActionResult GetAllVehicleOwners()
        {
            try
            {
                var vehicalOwners = userRepository.GetAllVehicalUsers();
                if (vehicalOwners == null)
                {
                    return BadRequest("NOT FOUND");
                }
                else {
                    return Ok(vehicalOwners);
                }
      
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("getvusernbyid")]
        public IActionResult GetVehicleOwnerById(Guid id)
        {
            try
            {
                var vehicleOwner = userRepository.GetVehicalUserById(id);

                if (vehicleOwner == null)
                {
                    return BadRequest("NOT FOUND");
                }
                else
                {
                    return Ok(vehicleOwner);
                }
             
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }

        }

        [HttpDelete]
        [Route("deletevuserbyid")]
        public async Task<IActionResult> DeleteExsistingVehicalUser(VehicleUser vehicaluser)
        {
            try
            {
                var result = await userRepository.DeleteExsistingVehicalUser(vehicaluser);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }


    }
}
