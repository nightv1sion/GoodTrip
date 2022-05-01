using System.ComponentModel.DataAnnotations;

namespace goodtrip.Models
{
    public class RegisterUser
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Passwords don`t match")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}
