using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace goodtrip.Models
{
    public class NewTourModel
    {
        [Required]
        public string TourName { get; set; }
        [Required]
        public string TourCity { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string TourCountry { get; set; }
        [Required]
        public string TourDescription { get; set; }
        [Required]
        public int TourMaxTourists { get; set; }
        [Required]
        public double TourPrice { get; set; }
        [Required]
        public int TourDuration { get; set; }
        [Required]

        public string HotelName { get; set; }
        [Required]
        public string HotelDescription { get; set; }
        [Required]
        public double HotelMark { get; set; }
        [Required]
        public string HotelCountry { get; set; }
        [Required]
        public string HotelCity { get; set; }
        [Required]
        public string HotelAddress { get; set; }
        [Required]
        public int HotelRooms { get; set; }
        [Required]
        public int HotelFreeRooms { get; set; }
        [Required]
        public string HotelIsWifi { get; set; }
        [Required]
        public string HotelFeeding { get; set; }
        [Required]

        public int ExcursionDuration { get; set; }
        [Required]
        public string ExcursionPlace { get; set; }
        [Required]
        public int ExcursionMaxAmountOfVisitors { get; set; }
        [Required]
        public string ExcursionLanguage { get; set; }
        [Required]
        public string ExcursionName { get; set; }
        [Required]
        public string ExcursionDescription { get; set; }
    }
}
