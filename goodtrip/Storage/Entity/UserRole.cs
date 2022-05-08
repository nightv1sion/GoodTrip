using Microsoft.AspNetCore.Identity;

namespace goodtrip.Storage.Entity
{
    public class UserRole : IdentityRole<Guid>
    {
        public UserRole() : base()
        {

        }
        public UserRole(string roleName) : base(roleName)
        {

        }
    }
}
