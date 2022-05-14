using System.ComponentModel.DataAnnotations;

namespace goodtrip.Storage.Entity
{
    public class Flight
    {
        [Key]
        public Guid FlightId { get; set; }
        public string Aviacompany { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public string Plane { get; set; }
        public double MaxBaggageWeight { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }

        public Guid TourID { get; set; }

        public Tour Tour { get; set; }
    }
}
