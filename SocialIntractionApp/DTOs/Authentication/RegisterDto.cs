using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SocialIntractionApp.DTOs.Authentication
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "First name is required. ")]
        [StringLength(50, ErrorMessage = "First name value cannot exceed 50 characters. ")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "Last name value cannot exceed 50 characters. ")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required. ")]
        [EmailAddress(ErrorMessage = "Email must in proper format. ")]
        [StringLength(50, ErrorMessage = "Email value cannot exceed 50 characters. ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required. ")]
        public string Password { get; set; }
    }
}
