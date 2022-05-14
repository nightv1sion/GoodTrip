using System.ComponentModel.DataAnnotations;

namespace goodtrip.Storage.Entity
{
    public class Transportation
    {
        [Key]
        public Guid TransportationId { get; set; }
        public string CompanyName { get; set; }

        public DateTime Date { get; set; }

        public string AeroportName { get; set; }

    }
}
