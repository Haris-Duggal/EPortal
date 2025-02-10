using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class SkillModel
    {
        public int SkillID { get; set; }
        public string? fk_UserID { get; set; }
        public string? SkillName { get; set; }
        public string? SkillType { get; set; }
        public string? TimeDuration { get; set; }
    }
}
