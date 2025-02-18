using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    /// <summary>
    /// ContactInfoModel
    /// </summary>
    public class ContactInfoModel
    {
        /// <summary>
        /// Foreign key for User
        /// </summary>
        public string? fk_UserID { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^\d{10,15}$", ErrorMessage = "Phone Number must be numeric and between 10 to 15 digits")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }

        public string? City { get; set; }
        public string? Area { get; set; }

        [Required(ErrorMessage = "Location is required")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Location cannot contain special characters")]
        public string? Location { get; set; }
    }
}
