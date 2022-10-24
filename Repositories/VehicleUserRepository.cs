using Fuel_Helper_API.Models;

namespace Fuel_Helper_API.Repositories
{
    public interface VehicleUserRepository
    {
        Task addUserAsync(VehicleUser user);
        List<VehicleUser> GetAllVehicalUsers();

        List<VehicleUser> GetVehicalUserById(Guid refId);

        Task<string> DeleteExsistingVehicalUser(VehicleUser vehicaluser);
    }
}
