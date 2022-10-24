using MongoDB.Bson.Serialization.Attributes;

namespace Fuel_Helper_API.Models
{
    public class QueueInfo
    {
        [BsonId]
        public Guid Id { get; set; }
        public Guid FuelStationReference { get; set; }
        public Guid VehicalOwnerId { get; set; }
        public string FuelType { get; set; }
        public DateTime? QInTime { get; set; }
        public DateTime? QOutTime { get; set; }
        public bool IsFuelAvailable { get; set; }
        public float NumberOfHoursInQueue { get; set; }
    }
}
