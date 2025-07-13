using System.ComponentModel.DataAnnotations;

namespace Library_Management_API.Models
{
    public class AppUser
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; } // ✅ Must be non-nullable

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Role { get; set; } = "User";
    }

}
