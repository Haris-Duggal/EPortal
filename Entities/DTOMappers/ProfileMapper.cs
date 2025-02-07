using Entities.DTOs;
using Entities.Models;

namespace Entities.DTOMappers
{
    public static class ProfileMapper
    {
        public static ProfileDTO ToDTO(this PersonalProfileModel model)
        {
            return new ProfileDTO
            {
                UserID = model.UserID,
                FirstName = model.FirstName,
                LastName = model.LastName,
                ProfilePictureUrl = model.ProfilePictureUrl,
                Bio = model.Bio,
                DateOfBirth = model.DateOfBirth,
                CreatedAt = model.CreatedAt,
                UpdatedAt = model.UpdatedAt
            };
        }

        public static PersonalProfileModel ToModel(this CreateProfileDTO dto)
        {
            return new PersonalProfileModel
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                ProfilePictureUrl = dto.ProfilePictureUrl,
                Bio = dto.Bio,
                DateOfBirth = dto.DateOfBirth
            };
        }

        public static PersonalProfileModel ToModel(this UpdateProfileDTO dto)
        {
            return new PersonalProfileModel
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                ProfilePictureUrl = dto.ProfilePictureUrl,
                Bio = dto.Bio,
                DateOfBirth = dto.DateOfBirth
            };
        }
    }
}



