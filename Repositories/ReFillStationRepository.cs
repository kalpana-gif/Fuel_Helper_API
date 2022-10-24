using Fuel_Helper_API.Models;

namespace Fuel_Helper_API.Repositories
{
    public interface ReFillStationRepository
    {
        Task addReFillStationAsync(ReFillStation refillstation);
    }
}
