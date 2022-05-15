using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace goodtrip.Storage.Entity
{
    public class Review
    {
        [Key]
        public Guid Id { get; set; }
        public string Text { get; set; }
        public int Mark { get; set; }
        public DateTime Created { get; set; }
        public Guid TourId { get; set; }
        public Tour Tour { get; set; }
    }
}
