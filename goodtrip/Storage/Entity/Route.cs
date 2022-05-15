namespace goodtrip.Storage.Entity
{
    public class Route
    {
        public Guid Id { get; set; }
        public string DepartureCity { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalCity { get; set; }
        public string ArrivalAirport { get; set; }
        public double Price { get; set; }
        public double Distance { get; set; }
        public Flight Flight { get; set; }
        public Guid FlightId { get; set; }
    }
}
