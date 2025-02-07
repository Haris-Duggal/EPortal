using Entities.DTOs;
using Entities.Models;

namespace Entities.DTOMappers
{
    public static class SkillMapper
    {
        public static SkillDTO ToDTO(this SkillModel model)
        {
            return new SkillDTO
            {
                fk_UserID = model.fk_UserID,
                Skill = model.Skill,
                SkillType = model.SkillType,
                TimeDuration = model.TimeDuration
            };
        }

        public static SkillModel ToModel(this CreateSkillDTO dto)
        {
            return new SkillModel
            {
                fk_UserID = dto.fk_UserID,
                Skill = dto.Skill,
                TimeDuration = dto.TimeDuration
            };
        }

        public static SkillModel ToModel(this UpdateSkillDTO dto)
        {
            return new SkillModel
            {
                fk_UserID = dto.fk_UserID,
                Skill = dto.Skill,
                TimeDuration = dto.TimeDuration
            };
        }
    }
}


