using System.ComponentModel.DataAnnotations;

namespace goodtrip.Models
{
    public class RequestModel
    {
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerLastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string TourId { get; set; }
        public string TourName { get; set; }
        public string RequestId { get; set; }
        public bool? IsReviewed { get; set; }
        [Required]
        public int AmountOfTourists { get; set; }
        [Required]
        public int Duration { get; set; }
        public string CustomerWishes { get; set; }
        public DateTime Created { get; set; }
    }
}
