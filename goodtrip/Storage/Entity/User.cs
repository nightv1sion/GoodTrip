using goodtrip.Models;
using goodtrip.Storage.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace goodtrip.Storage.Entity
{
    public class User : IdentityUser<Guid>
    {
        [BindProperty]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [BindProperty]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required]
        public UserProfile Profile { get; set; }
        [EnumDataType(typeof(AccountType))]
        [Required(ErrorMessage = "Type of account is required")]
        public AccountType AccountType { get; set; }
    }
    
}
