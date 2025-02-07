using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class PersonalProfileModel
    {
        public string? UserID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? Bio { get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? DateOfBirth { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
