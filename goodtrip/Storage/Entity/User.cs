using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace goodtrip.Storage.Entity
{
    public class User
    {
        public Guid Id { get; set; }
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Login is required")]
        [BindProperty]
        public string LoginName { get; set; }
        [BindProperty]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Username is required")]
        [Display(Name = "Username")]
        public string UserName { get; set; }
    }
}
