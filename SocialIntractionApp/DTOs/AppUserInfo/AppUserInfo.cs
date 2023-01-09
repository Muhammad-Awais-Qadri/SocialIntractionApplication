using System.ComponentModel.DataAnnotations;

namespace SocialIntractionApp.DTOs.AppUserInfo
{
    public class AppUserInfo
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
