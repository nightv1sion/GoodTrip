using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace goodtrip.Storage.Entity
{
    public class User : IdentityUser
    {
        public Guid Id { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [BindProperty]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
