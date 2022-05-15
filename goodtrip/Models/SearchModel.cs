using goodtrip.Storage.Entity;
using System.ComponentModel.DataAnnotations;

namespace goodtrip.Models
{
    public class SearchModel
    {
        [Required]
        public string Place { get; set; }
        [Required]
        public DateTime DateOfStart { get; set; }
        public DateTime DateOfEnd { get; set; }
        public List<TourModel> Tours { get; set; }

    }
}
