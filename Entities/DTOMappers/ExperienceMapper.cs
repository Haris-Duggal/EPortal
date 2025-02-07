using Entities.DTOs;
using Entities.Models;

namespace Entities.DTOMappers
{
    public static class ExperienceMapper
    {
        public static ExperienceDTO ToDTO(this ExperienceModel model)
        {
            return new ExperienceDTO
            {
                ExperienceID = model.ExperienceID,
                fk_UserID = model.fk_UserID,
                Title = model.Title,
                EmploymentType = model.EmploymentType,
                CompanyName = model.CompanyName,
                CurrentlyWorking = model.CurrentlyWorking,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Location = model.Location,
                LocationType = model.LocationType,
                Description = model.Description
            };
        }

        public static ExperienceModel ToModel(this CreateExperienceDTO dto)
        {
            return new ExperienceModel
            {
                Title = dto.Title,
                EmploymentType = dto.EmploymentType,
                CompanyName = dto.CompanyName,
                CurrentlyWorking = dto.CurrentlyWorking,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Location = dto.Location,
                LocationType = dto.LocationType,
                Description = dto.Description
            };
        }

        public static ExperienceModel ToModel(this UpdateExperienceDTO dto)
        {
            return new ExperienceModel
            {
                ExperienceID = dto.ExperienceID,
                Title = dto.Title,
                EmploymentType = dto.EmploymentType,
                CompanyName = dto.CompanyName,
                CurrentlyWorking = dto.CurrentlyWorking,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Location = dto.Location,
                LocationType = dto.LocationType,
                Description = dto.Description
            };
        }
    }
}
