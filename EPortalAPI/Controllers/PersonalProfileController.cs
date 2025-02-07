using Entities.DTOs;
using Entities.DTOMappers;
using EPortalAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace EPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalProfileController : ControllerBase
    {
        private readonly IPersonalProfileService _personalProfileService;

        public PersonalProfileController(IPersonalProfileService personalProfileService)
        {
            _personalProfileService = personalProfileService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProfileDTO>>> PersonalProfileModels()
        {
            try
            {
                var result = await _personalProfileService.PersonalProfileModels("SP_Get_Profile");
                return Ok(result.Select(static model => model.ToDTO()).ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<ProfileDTO>> PersonalProfileModel(string userId)
        {
            try
            {
                SqlParameter[] sp =
                {
                    new SqlParameter("@UserID", userId)
                };
                var result = await _personalProfileService.PersonalProfileModel("SP_Get_ProfileById", sp);
                return Ok(result.ToDTO());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreatePersonalProfileModel(CreateProfileDTO createProfileDTO)
        {
            try
            {
                var ppm = createProfileDTO.ToModel();
                SqlParameter[] sp =
                {
                    new SqlParameter("@FirstName", ppm.FirstName),
                    new SqlParameter("@LastName", ppm.LastName),
                    new SqlParameter("@ProfilePictureUrl", ppm.ProfilePictureUrl),
                    new SqlParameter("@Bio", ppm.Bio),
                    new SqlParameter("@DateOfBirth", ppm.DateOfBirth)
                };
                await _personalProfileService.CreatePersonalProfileModel("SP_Post_Profile", sp);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult> UpdatePersonalProfileModel(string userId, UpdateProfileDTO updateProfileDTO)
        {
            try
            {
                var ppm = updateProfileDTO.ToModel();
                SqlParameter[] sp =
                {
                    new SqlParameter("@UserID", userId),
                    new SqlParameter("@FirstName", ppm.FirstName),
                    new SqlParameter("@LastName", ppm.LastName),
                    new SqlParameter("@ProfilePictureUrl", ppm.ProfilePictureUrl),
                    new SqlParameter("@Bio", ppm.Bio),
                    new SqlParameter("@DateOfBirth", ppm.DateOfBirth)
                };
                await _personalProfileService.UpdatePersonalProfileModel("SP_Put_Profile", sp);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult> DeletePersonalProfileModel(string userId)
        {
            try
            {
                SqlParameter[] sp =
                {
                    new SqlParameter("@UserID", userId)
                };
                await _personalProfileService.DeletePersonalProfileModel("SP_Delete_Profile", sp);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
