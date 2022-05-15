using System.ComponentModel.DataAnnotations;

namespace goodtrip.Storage.Entity
{
    public class Flight
    {
        [Key]
        public Guid Id { get; set; }
        public string Aviacompany { get; set; }
        public List<Route> Routes { get; set; }
        public string Plane { get; set; }
        public double MaxBaggageWeight { get; set; }
        public Guid TourId { get; set; }
        public Tour Tour { get; set; }
    }
}
