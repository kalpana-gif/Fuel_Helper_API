using Fuel_Helper_API.Models;

namespace Fuel_Helper_API.Repositories
{
    public interface VehicleUserRepository
    {
        Task addUserAsync(VehicleUser user);
    }
}
