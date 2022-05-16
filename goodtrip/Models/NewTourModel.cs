using System.ComponentModel.DataAnnotations.Schema;

namespace goodtrip.Models
{
    public class NewTourModel
    {
        public string TourName { get; set; }
        public string TourCity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TourCountry { get; set; }
        public string TourDescription { get; set; }
        public int TourMaxTourists { get; set; }
        public double TourPrice { get; set; }
        public int TourDuration { get; set; }
        public string TourOperator { get; set; }

        public string HotelName { get; set; }
        public string HotelDescription { get; set; }
        public double HotelMark { get; set; }
        public string HotelCountry { get; set; }
        public string HotelCity { get; set; }
        public string HotelAddress { get; set; }
        public int HotelRooms { get; set; }
        public int HotelFreeRooms { get; set; }
        public string HotelIsWifi { get; set; }
        public string HotelFeeding { get; set; }

        public int ExcursionDuration { get; set; }
        public string ExcursionPlace { get; set; }
        public int ExcursionMaxAmountOfVisitors { get; set; }
        public string ExcursionLanguage { get; set; }
        public string ExcursionName { get; set; }
        public string ExcursionDescription { get; set; }

    }
}
