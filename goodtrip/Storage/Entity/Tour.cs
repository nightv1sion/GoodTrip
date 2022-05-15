using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace goodtrip.Storage.Entity
{
    public class Tour
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        [Column(TypeName = "nvarchar(4000)")]
        public string Description { get; set; }
        public int MaxTourists { get; set; }
        public double Price { get; set; }
        public int Duration { get; set; }
        public List<Excurtion> Excurtion { get; set; }
        public Hotel Hotel { get; set; }
        public List<Review> Review { get; set; }
        public string TourOperator { get; set; }
    }
}
