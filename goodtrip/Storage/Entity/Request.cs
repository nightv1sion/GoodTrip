using System.ComponentModel.DataAnnotations;

namespace goodtrip.Storage.Entity
{
    public class Request
    {
        [Key]
        public Guid Id { get; set; }
        public Tour Tour { get; set; }
        public Guid TourId { get; set; }
        public Guid CustomerProfileId { get; set; }
        public Guid OperatorProfileId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerLastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Created { get; set; }
    }
}
