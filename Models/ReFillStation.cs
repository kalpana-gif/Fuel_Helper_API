using MongoDB.Bson.Serialization.Attributes;

namespace Fuel_Helper_API.Models
{
    public class ReFillStation
    {
        [BsonId]
        public Guid Id { get; set; }
        public string StationName { get; set; }
        public string Address { get; set; }
        public string RegistrationNumber { get; set; }
    }
}
