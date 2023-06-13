using System.ComponentModel.DataAnnotations;

namespace AspNetCore_Project.Dtos
{
    public class UserData
    {
        public int Id { get; set; }

        public string? UserName { get; set; }

        public string? UserEmail { get; set; }

        public string? Role { get; set; }

        public string? Token { get; set; }
    }
}
