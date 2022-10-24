using MongoDB.Bson.Serialization.Attributes;

namespace Fuel_Helper_API.Models
{
    public class VehicleUser
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Username { get; set; }

        public string Adress { get; set; }

        public string FuelType { get; set; }

        public string VehicleNumber { get; set; }

    }
}
