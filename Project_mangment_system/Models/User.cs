using System.ComponentModel.DataAnnotations;

namespace Project_management_system.Models
{
    public class User : BaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string? Otp { get; set; }
        public DateTime? OtpExpiry { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string ImageURL { get; set; }
        [Required]
        public string Country { get; set; }
        public bool IsVerified { get; set; }

    }
}
