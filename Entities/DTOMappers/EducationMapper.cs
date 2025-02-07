using Entities.DTOs;
using Entities.Models;

namespace Entities.DTOMappers
{
    public static class EducationMapper
    {
        public static EducationDTO ToDTO(this EducationModel model)
        {
            return new EducationDTO
            {
                EducationID = model.EducationID,
                fk_UserID = model.fk_UserID,
                InstituteName = model.InstituteName,
                Degree = model.Degree,
                FieldOfStudy = model.FieldOfStudy,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Range = model.Range
            };
        }

        public static EducationModel ToModel(this CreateEducationDTO dto)
        {
            return new EducationModel
            {
                InstituteName = dto.InstituteName,
                Degree = dto.Degree,
                FieldOfStudy = dto.FieldOfStudy,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Range = dto.Range
            };
        }

        public static EducationModel ToModel(this UpdateEducationDTO dto)
        {
            return new EducationModel
            {
                EducationID = dto.EducationID,
                InstituteName = dto.InstituteName,
                Degree = dto.Degree,
                FieldOfStudy = dto.FieldOfStudy,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Range = dto.Range
            };
        }
    }
}
