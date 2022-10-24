using Fuel_Helper_API.Models;
using Fuel_Helper_API.Repositories;
using Microsoft.AspNetCore.Mvc;

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
    }
}
