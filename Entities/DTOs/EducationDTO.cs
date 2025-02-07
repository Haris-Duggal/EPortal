namespace Entities.DTOs
{
    public class EducationDTO
    {
        public int EducationID { get; set; }
        public string? fk_UserID { get; set; }
        public string? InstituteName { get; set; }
        public string? Degree { get; set; }
        public string? FieldOfStudy { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string? Range { get; set; }
    }

    public class CreateEducationDTO
    {
        public string? InstituteName { get; set; }
        public string? Degree { get; set; }
        public string? FieldOfStudy { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string? Range { get; set; }
    }

    public class UpdateEducationDTO
    {
        public int EducationID { get; set; }
        public string? InstituteName { get; set; }
        public string? Degree { get; set; }
        public string? FieldOfStudy { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string? Range { get; set; }
    }
}
