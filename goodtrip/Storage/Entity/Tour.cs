using System.ComponentModel.DataAnnotations;

namespace goodtrip.Storage.Entity
{
    public class Tour
    {
        [Key]
        public Guid Id { get; set; }
        public List<DepartureCity> DepartureCities { get; set; } = new();
        public string ArrivalCity { get; set; }
        public List<Date> Dates { get; set; } = new();
        public int Nights { get; set; }
        public int MaxTourists { get; set; }

        public int Duration { get; set; }

        public Flight FlightTo { get; set; }

        public Flight FlightBack { get; set; }

        public Hotel Hotel { get; set; }

        public List<Excurtion> Excurtion { get; set; }

        public List<Review> Review { get; set; }

    }
}
