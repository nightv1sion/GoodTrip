using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace goodtrip.Storage.Entity
{
    public class User
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Login is required")]
        [BindProperty]
        public string LoginName { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

    }
}
