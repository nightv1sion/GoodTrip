using System.ComponentModel.DataAnnotations;

namespace goodtrip.Models
{
    public class RegisterUser
    {
        [Required]
        public string Login { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [Display(Name = "Repeat Password")]
        [Compare("Password", ErrorMessage = "Passwords don`t match")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
        [Required(ErrorMessage = "Type of account is required")]
        public string AccountType { get; set; }
    }

    
}
