using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class ExperienceModel
    {
        public int ExperienceID { get; set; }

        public string? fk_UserID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Employment Type is required")]
        public string? EmploymentType { get; set; }

        [Required(ErrorMessage = "Company Name is required")]
        public string? CompanyName { get; set; }

        public bool CurrentlyWorking { get; set; }

        [Required(ErrorMessage = "Start Date is required")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? StartDate { get; set; }

        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? EndDate { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string? Location { get; set; }

        [Required(ErrorMessage = "Location Type is required")]
        public string? LocationType { get; set; }

        public string? Description { get; set; }
    }
}
