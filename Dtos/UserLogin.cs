using System.ComponentModel.DataAnnotations;

namespace AspNetCore_Project.Dtos
{
    public class UserLogin
    {
        [Required]
        public string UserEmail { get; set; } = null!;
        [Required]
        public string UserPassword { get; set; } = null!;
    }
}
