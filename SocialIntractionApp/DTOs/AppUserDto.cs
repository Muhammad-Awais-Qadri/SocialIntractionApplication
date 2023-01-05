using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SocialIntractionApp.DTOs
{
    public class RegisterDto
    {
        [Required]
        [StringLength(50, ErrorMessage = "The First Name value cannot exceed 50 characters. ")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "The Last Name value cannot exceed 50 characters. ")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50, ErrorMessage = "The Email value cannot exceed 50 characters. ")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
