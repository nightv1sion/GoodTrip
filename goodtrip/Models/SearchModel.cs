using goodtrip.Storage.Entity;
using System.ComponentModel.DataAnnotations;

namespace goodtrip.Models
{
    public class SearchModel
    {
        [Required]
        public string PlaceFrom { get; set; }
        [Required]
        public string PlaceTo { get; set; }
        [Required]
        public DateTime When { get; set; }
        public int? Nights { get; set; }
        public int? Tourists { get; set; }
        public List<Tour> Tours { get; set; }

    }
}
