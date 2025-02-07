using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class EducationModel
    {
        public int EducationID { get; set; }
        public string? fk_UserID { get; set; }
        public string? InstituteName { get; set; }
        public string? Degree { get; set; }
        public string? FieldOfStudy { get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly StartDate { get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly EndDate { get; set; }
        public string? Range { get; set; }

    }
}