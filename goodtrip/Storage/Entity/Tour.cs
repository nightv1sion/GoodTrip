using System.ComponentModel.DataAnnotations;

namespace goodtrip.Storage.Entity
{
    public class Tour
    {
        [Key]
        public Guid Id { get; set; }
        public string City { get; set; }

        public string Country { get; set; }
        public DateTime Date { get; set; }
        public int MaxTourists { get; set; }

        public double Price { get; set; }
        public int Duration { get; set; }
        public List<Excurtion> Excurtion { get; set; }

        public List<Flight> Flight { get; set; }

       // public Flight FlightBack { get; set; }

        public Hotel Hotel { get; set; }

        public List<Review> Review { get; set; }

        public UserProfile TourOperator { get; set; }

    }
}
