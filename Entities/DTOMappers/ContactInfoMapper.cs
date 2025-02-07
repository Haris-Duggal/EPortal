
using Entities.Models;

namespace Entities.DTOs
{
    public static class ContactInfoMapper
    {
        public static ContactInfoDTO ToDTO(this ContactInfoModel model)
        {
            return new ContactInfoDTO
            {
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Location = model.Location
            };
        }

        public static ContactInfoModel ToModel(this CreateContactInfoDTO dto)
        {
            return new ContactInfoModel
            {
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                Location = dto.Location
            };
        }

        public static ContactInfoModel ToModel(this UpdateContactInfoDTO dto)
        {
            return new ContactInfoModel
            {
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                Location = dto.Location
            };
        }
    }
}
