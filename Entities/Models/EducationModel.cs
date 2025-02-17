using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class EducationModel
    {
        
        public int EducationID { get; set; }
        public string? fk_UserID { get; set; }
        [Required(ErrorMessage = "Institute Name is Required")]
        public string? InstituteName { get; set; }
        [Required(ErrorMessage = "Degree is Required")]
        public string? Degree { get; set; }
        [Required(ErrorMessage = "Field of Study is Required")]
        public string? FieldOfStudy { get; set; }
        [Required(ErrorMessage ="Starting Date is Required")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly StartDate { get; set; }
        [Required(ErrorMessage = "End Date is Required")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly EndDate { get; set; }
        [Required(ErrorMessage = "Grade is Required")]
        public string? Range { get; set; }

    }
}