using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ContactInfoModel
    {
        public string? fk_UserID { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int City { get; set; }
        public int Area { get; set; }
        public string? Location { get; set; }

    }
}
