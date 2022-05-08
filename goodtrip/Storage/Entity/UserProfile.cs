using goodtrip.Storage.Enums;
using System.ComponentModel.DataAnnotations;

namespace goodtrip.Storage.Entity
{
    public abstract class UserProfile
    {
        [Key]
        public Guid UserProfileId { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDay { get; set; }
        [EnumDataType(typeof(Nationality))]
        public Nationality Nationality { get; set; }
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }
        public string? PassportNumber { get; set; }
        public DateTime PassportValidityPeriod { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
