namespace goodtrip.Models
{
    public class TourModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageDataUrl { get; set; }
    }
}
