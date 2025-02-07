using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class ExperienceModel
    {
        public int ExperienceID { get; set; }
        public string? fk_UserID { get; set; }
        public string? Title { get; set; }
        public string? EmploymentType { get; set; }
        public string? CompanyName { get; set; }
        public bool CurrentlyWorking { get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? StartDate { get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? EndDate { get; set; }
        public string? Location { get; set; }
        public string? LocationType { get; set; }
        public string? Description { get; set; }
    }
}