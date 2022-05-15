using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace goodtrip.Storage.Entity
{
    public class Excurtion
    {
        [Key]
        public Guid Id { get; set; }
        public int Duration { get; set; }
        public string Place { get; set; }
        public int MaxAmountOfVisitors { get; set; }
        public string Language { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(4000)")]
        public string Description { get; set; }
        public List<ImageExcurtion> Images { get; set; }
        public Guid TourId { get; set; }
        public Tour Tour { get; set; }
    }
}
