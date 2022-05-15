using System.ComponentModel.DataAnnotations;

namespace goodtrip.Storage.Entity
{
    public class Route
    {
        [Key] 
        public Guid Id { get; set; }
        public string DepartureCity { get; set; }
        public string DepartureAirport { get; set; }
        public DateTime DepartureTime { get; set; }
        public string ArrivalCity { get; set; }
        public string ArrivalAirport { get; set; }
        public DateTime ArrivalTime { get; set; }
        public Flight Flight { get; set; }
        public Guid FlightId { get; set; }
    }
}
