
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace goodtrip.Storage.Entity
{
    public class Hotel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName="varchar")]
        [MaxLength]
        public string Description { get; set; }
        public double Mark { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int Rooms { get; set; }
        public int FreeRooms { get; set; }
        public bool IsWifi { get; set; }
        public bool Feeding { get; set; }
        public List<ImageHotel> Images { get; set; }
        public Guid TourId { get; set; }
        public Tour Tour { get; set; }

    }
}
