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


    }
}
