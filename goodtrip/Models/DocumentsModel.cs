namespace goodtrip.Models
{
    public class DocumentsModel
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public string PassNumber { get; set; }
        public DateTime PassValidityPeriod { get; set; }
    }
}
