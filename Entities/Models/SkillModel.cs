using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class SkillModel
    {
        public int SkillID { get; set; }
        public string? fk_UserID { get; set; }

        [Required(ErrorMessage = "Skill Name is required.")]
        public string? SkillName { get; set; }

        [Required(ErrorMessage = "Skill Type is required.")]
        public string? SkillType { get; set; }

        [Required(ErrorMessage = "Time Duration is required.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Time Duration must be a numeric value.")]
        public string? TimeDuration { get; set; }
    }
}
