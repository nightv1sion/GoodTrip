using System.ComponentModel.DataAnnotations;

namespace goodtrip.Storage.Entity
{
    public class ImageHotel
    {
        [Key]
        public Guid Id { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public Guid HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
