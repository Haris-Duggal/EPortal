using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class EducationModel
    {
        public int EducationID { get; set; }
        public string? fk_UserID { get; set; }

        [Required(ErrorMessage = "Institute Name is required")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Institute Name cannot contain special characters")]
        public string? InstituteName { get; set; }

        [Required(ErrorMessage = "Degree is required")]
        
        public string? Degree { get; set; }

        [Required(ErrorMessage = "Field of Study is required")]
        
        public string? FieldOfStudy { get; set; }

        [Required(ErrorMessage = "Starting Date is required")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        [Compare(nameof(StartDate), ErrorMessage = "End Date cannot be earlier than Start Date")]
        public DateOnly EndDate { get; set; }

        [Required(ErrorMessage = "Grade is required")]
        [RegularExpression(@"^(?:[0-9]{1,2}(?:\.[0-9]{1,2})?|[A-F][+-]?)$",
            ErrorMessage = "Grade must be a valid percentage (e.g., 85.5) or letter grade (e.g., A, B+)")]
        public string? Range { get; set; }
    }
}
