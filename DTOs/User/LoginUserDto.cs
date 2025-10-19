using System.ComponentModel.DataAnnotations;

namespace Library_Management_API.DTOs.User
{
    public class LoginUserDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6,ErrorMessage ="Password should be longer than 6 digits")]
        public string Password { get; set; }
    }
}
