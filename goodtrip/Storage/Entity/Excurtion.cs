using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace goodtrip.Storage.Entity
{
    public class Excurtion
    {
        [Key]
        public Guid Id { get; set; }
        public double Price { get; set; }
        public int Duration { get; set; }
        public string Place { get; set; }
        public DateTime TimeDate { get; set; }
        public int MaxAmountOfVisitors { get; set; }
        public string Language { get; set; }
        public bool Feeding { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength]
        public string Description { get; set; }
        public List<ImageExcurtion> Images { get; set; }
        public Guid TourId { get; set; }
        public Tour Tour { get; set; }
    }
}
