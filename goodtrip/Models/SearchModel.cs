using goodtrip.Storage.Entity;
using System.ComponentModel.DataAnnotations;

namespace goodtrip.Models
{
    public class SearchModel
    {
        public string? Place { get; set; }
        public DateTime? DateOfStart { get; set; }
        public DateTime? DateOfEnd { get; set; }
        public int? PriceStart { get; set; }
        public int? PriceEnd { get; set; }
        public bool? IsFeeding { get; set; }
        public int? AmountOfStartOfHotel { get; set; }
        public bool? IsWifi { get; set; }
        public int? Duration { get; set; }
        public string? Country { get; set; }
        public string? ExcursionLanguage { get; set; }
        public List<TourModel> Tours { get; set; }

    }
}
