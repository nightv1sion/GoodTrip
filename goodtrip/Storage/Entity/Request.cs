namespace goodtrip.Storage.Entity
{
    public class Request
    {
        public Guid Id { get; set; }
        public Tour Tour { get; set; }
        public Guid TourId { get; set; }
        public UserCustomerProfile Customer { get; set; }
        public Guid CustomerProfileId { get; set; }
        public UserOperatorProfile Operator { get; set; }
        public Guid OperatorProfileId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerLastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
