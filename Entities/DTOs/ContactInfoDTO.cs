namespace Entities.DTOs
{
    public class ContactInfoDTO
    {
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Location { get; set; }
    }

    public class CreateContactInfoDTO
    {
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Location { get; set; }
    }

    public class UpdateContactInfoDTO
    {
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Location { get; set; }
    }
}
