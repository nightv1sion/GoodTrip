﻿using System.ComponentModel.DataAnnotations;

namespace goodtrip.Models
{
    public class LoginUser
    {
        [Required]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
