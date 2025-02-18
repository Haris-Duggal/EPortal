using System.ComponentModel.DataAnnotations;
namespace Entities.Models
{
    /// <summary>
    /// Con.tactInfoModel
    /// </summary>
    public class ContactInfoModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string? fk_UserID { get; set; }
        [Required(ErrorMessage = "Phone Number is requried")]
        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage ="Email is Required")]
        public string? Email { get; set; }
        
        public string? City { get; set; }
        public string? Area { get; set; }
        [Required(ErrorMessage ="Location is Required")]
        public string? Location { get; set; }

    }
}
