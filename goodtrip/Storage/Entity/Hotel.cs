namespace goodtrip.Storage.Entity
{
    public class Hotel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Mark { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int Rooms { get; set; }
        public int FreeRooms { get; set; }
        public bool IsWifi { get; set; }
        public string Food { get; set; }
        public string TypeOfFood { get; set; }

        public Guid TourId { get; set; }

        public Tour Tour { get; set; }

    }
}
