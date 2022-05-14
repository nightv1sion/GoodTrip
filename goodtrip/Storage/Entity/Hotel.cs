namespace goodtrip.Storage.Entity
{
    public class Hotel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Mark { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string TypeOfFood { get; set; }
    }
}
