namespace Entities.DTOs
{
    public class ProfileDTO
    {
        public string? UserID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? Bio { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class CreateProfileDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? Bio { get; set; }
        public DateOnly? DateOfBirth { get; set; }
    }

    public class UpdateProfileDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? Bio { get; set; }
        public DateOnly? DateOfBirth { get; set; }
    }
}



