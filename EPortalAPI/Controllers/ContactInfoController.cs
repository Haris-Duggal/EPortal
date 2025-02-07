using Entities.DTOs;
using EPortalAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace EPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfoController : ControllerBase
    {
        private readonly IContactInfoService _contactInfoService;

        public ContactInfoController(IContactInfoService contactInfoService)
        {
            _contactInfoService = contactInfoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ContactInfoDTO>>> ContactInfoModels()
        {
            try
            {
                var result = await _contactInfoService.ContactInfoModels("SP_Get_ContactInfo");
                return Ok(result.Select(static model => model.ToDTO()).ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<ContactInfoDTO>> ContactInfoModel(string userId)
        {
            try
            {
                SqlParameter[] sp =
                {
                    new SqlParameter("@fk_UserID", userId)
                };
                var result = await _contactInfoService.ContactInfoModel("SP_Get_ContactInfoById", sp);
                return Ok(result.ToDTO());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateContactInfoModel(CreateContactInfoDTO createContactInfoDTO)
        {
            try
            {
                var contactInfoModel = createContactInfoDTO.ToModel();
                SqlParameter[] sp =
                {
                    new SqlParameter("@fk_UserID", "911"),
                    new SqlParameter("@PhoneNumber", contactInfoModel.PhoneNumber),
                    new SqlParameter("@Email", contactInfoModel.Email),
                    new SqlParameter("@fk_City", 1),
                    new SqlParameter("@fk_Area", 2),
                    new SqlParameter("@Location", contactInfoModel.Location)
                };

                await _contactInfoService.CreateContactInfoModel("SP_Post_ContactInfo", sp);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult> UpdateContactInfoModel(string userId, UpdateContactInfoDTO updateContactInfoDTO)
        {
            try
            {
                var contactInfoModel = updateContactInfoDTO.ToModel();
                SqlParameter[] sp =
                {
                    new SqlParameter("@fk_UserID", "911"),
                    new SqlParameter("@PhoneNumber", contactInfoModel.PhoneNumber),
                    new SqlParameter("@Email", contactInfoModel.Email),
                    new SqlParameter("@fk_City", 1),
                    new SqlParameter("@fk_Area", 2),
                    new SqlParameter("@Location", contactInfoModel.Location)
                };
                await _contactInfoService.UpdateContactInfoModel("SP_Put_ContactInfo", sp);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult> DeleteContactInfoModel(string userId)
        {
            try
            {
                SqlParameter[] sp =
                {
                    new SqlParameter("@fk_UserID", "911")
                };
                await _contactInfoService.DeleteContactInfoModel("SP_Delete_ContactInfo", sp);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
