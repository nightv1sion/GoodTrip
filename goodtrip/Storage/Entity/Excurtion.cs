using System.ComponentModel.DataAnnotations;

namespace goodtrip.Storage.Entity
{
    public class Excurtion
    {
        [Key]
        public Guid Id { get; set; }
        public double Price { get; set; }
        public int Duration { get; set; }
        public string Place { get; set; }
        public DateTime TimeDate { get; set; }
        public int MaxAmountOfVisitors { get; set; }
        public string Language { get; set; }
        public string Feeding { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
