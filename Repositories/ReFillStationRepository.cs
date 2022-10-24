using Fuel_Helper_API.Models;

namespace Fuel_Helper_API.Repositories
{
    public interface ReFillStationRepository
    {
        Task addReFillStationAsync(ReFillStation refillstation);

        List<ReFillStation> GetAllReFillStations();

        List<ReFillStation> GetRefillStationById(Guid refId);

        Task<ReFillStation> UpdateRefillStation(ReFillStation refillstation);

        Task<string> DeleteExistingReFillStation(ReFillStation refillstation);
    }
}
