using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class ExperienceModel
    {
        public int ExperienceID { get; set; }

        public string? fk_UserID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Title cannot contain special characters")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Employment Type is required")]
        public string? EmploymentType { get; set; }

        [Required(ErrorMessage = "Company Name is required")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Company Name cannot contain special characters")]
        public string? CompanyName { get; set; }

        public bool CurrentlyWorking { get; set; }

        [Required(ErrorMessage = "Start Date is required")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateOnly? StartDate { get; set; }

        [JsonConverter(typeof(DateOnlyJsonConverter))]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateOnly? EndDate { get; set; }

        [Required(ErrorMessage = "Location is required")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Location cannot contain special characters")]
        public string? Location { get; set; }

        [Required(ErrorMessage = "Location Type is required")]
        public string? LocationType { get; set; }

        public string? Description { get; set; }
    }
}
