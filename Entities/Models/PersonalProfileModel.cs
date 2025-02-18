using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class PersonalProfileModel
    {
        public string? UserID { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "First Name cannot contain special characters")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Last Name cannot contain special characters")]
        public string? LastName { get; set; }

        public string? ProfilePictureUrl { get; set; }

        public string? Bio { get; set; }

        [JsonConverter(typeof(DateOnlyJsonConverter))]
        [Required(ErrorMessage = "Date of Birth is required")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateOnly? DateOfBirth { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
