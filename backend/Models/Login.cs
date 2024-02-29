using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Login
    {
        public string? UserName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public required string Password { get; set; }
    }
}
