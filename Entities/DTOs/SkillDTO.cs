namespace Entities.DTOs
{
    public class SkillDTO
    {
        public string? fk_UserID { get; set; }
        public string? Skill { get; set; }
        public string? SkillType { get; set; }
        public string? TimeDuration { get; set; }
    }

    public class CreateSkillDTO
    {
        public string? fk_UserID { get; set; }
        public string? Skill { get; set; }
        public string? TimeDuration { get; set; }
    }

    public class UpdateSkillDTO
    {
        public string? fk_UserID { get; set; }
        public string? Skill { get; set; }
        public string? TimeDuration { get; set; }
    }
}


