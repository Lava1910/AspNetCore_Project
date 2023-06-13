using System.ComponentModel.DataAnnotations;

namespace AspNetCore_Project.Dtos
{
    public class UserLogin
    {
        public string? UserEmail { get; set; }

        public string? UserPassword { get; set; }
    }
}
