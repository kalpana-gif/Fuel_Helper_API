using MongoDB.Bson.Serialization.Attributes;

namespace Fuel_Helper_API.Models
{
    public class FuelStatusManagement
    {
        [BsonId]
        public Guid Id { get; set; }
        public Guid FuelStationReference { get; set; }   //simillar to id
                                                        
        public bool PetorlAvailabilty { get; set; }

        public bool DiselAvailabilty { get; set; }

        public bool KeroseneAvailabilty { get; set; }

        public int OnboardPetrolVehicles { get; set; }

        public int OnboardDieselVehicles { get; set; }

        public int OnboardKeroseneUsers { get; set; }

        public float AvarageWaitingTimeInQueue { get; set; }

        public int TotalNumberOfVehicalsReFilled { get; set; }


    }
}
