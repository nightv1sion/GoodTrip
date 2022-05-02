using System.ComponentModel.DataAnnotations;

namespace goodtrip.Storage.Entity
{
    public class UserProfile
    {
        [Key]
        public Guid UserProfileId { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
