namespace Entities.DTOs
{
    public class ExperienceDTO
    {
        public int ExperienceID { get; set; }
        public string? fk_UserID { get; set; }
        public string? Title { get; set; }
        public string? EmploymentType { get; set; }
        public string? CompanyName { get; set; }
        public bool CurrentlyWorking { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public string? Location { get; set; }
        public string? LocationType { get; set; }
        public string? Description { get; set; }
    }

    public class CreateExperienceDTO
    {
        public string? Title { get; set; }
        public string? EmploymentType { get; set; }
        public string? CompanyName { get; set; }
        public bool CurrentlyWorking { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public string? Location { get; set; }
        public string? LocationType { get; set; }
        public string? Description { get; set; }
    }

    public class UpdateExperienceDTO
    {
        public int ExperienceID { get; set; }
        public string? Title { get; set; }
        public string? EmploymentType { get; set; }
        public string? CompanyName { get; set; }
        public bool CurrentlyWorking { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public string? Location { get; set; }
        public string? LocationType { get; set; }
        public string? Description { get; set; }
    }
}
