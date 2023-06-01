using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore_Project.Dtos
{
    public class UserRegister
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        public string UserEmail { get; set; } = null!;
        [Required]
        public string UserPassword { get; set; } = null!;
        [Required]
        public string Role { get; set; } = null!;
    }
}
