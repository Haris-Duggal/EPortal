using Entities.DTOs;
using Entities.DTOMappers;
using Entities;
using EPortal.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace EPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceService _experienceService;

        public ExperienceController(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetExperienceModels()
        {
            try
            {
                var experienceModels = await _experienceService.GetExperienceModels("SP_Get_Experiences");
                return Ok(experienceModels.Select(static model => model.ToDTO()).ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetExperienceModel(string userId)
        {
            try
            {
                SqlParameter[] sp =
                {
                   new SqlParameter("@fk_UserID", userId)
                };
                var experienceModel = await _experienceService.GetExperienceModel("SP_Get_ExperiencesById", sp);
                return Ok(experienceModel.Select(static model => model.ToDTO()).ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddExperience(CreateExperienceDTO createExperienceDTO)
        {
            try
            {
                var model = createExperienceDTO.ToModel();
                SqlParameter[] sp =
                {
                    new SqlParameter ("@fk_UserId", "911"),
                    new SqlParameter("@Title", model.Title),
                    new SqlParameter("@EmployementType", model.EmploymentType),
                    new SqlParameter("@CompanyName", model.CompanyName),
                    new SqlParameter("@CurrentlyWorking", model.CurrentlyWorking),
                    new SqlParameter("@StartDate", model.StartDate),
                    new SqlParameter("@EndDate", model.EndDate),
                    new SqlParameter("@Location", model.Location),
                    new SqlParameter("@LocationType", model.LocationType),
                    new SqlParameter("@Description", model.Description),
                };
                await _experienceService.AddExperience("SP_Post_Experience", sp);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveExperience(int id)
        {
            try
            {
                SqlParameter[] sp =
                    {
                    new SqlParameter("@ExperienceID", id)
                    };
                await _experienceService.RemoveExperience("SP_Delete_Experience", sp);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{ExpId}")]
        public async Task<IActionResult> UpdateExperience(UpdateExperienceDTO updateExperienceDTO)
        {
            try
            {
                var model = updateExperienceDTO.ToModel();
                SqlParameter[] sp =
                {
                new SqlParameter("@ExperienceID", model.ExperienceID),
                new SqlParameter("@Title", model.Title),
                new SqlParameter("@EmployementType", model.EmploymentType),
                new SqlParameter("@CompanyName", model.CompanyName),
                new SqlParameter("@CurrentlyWorking", model.CurrentlyWorking),
                new SqlParameter("@StartDate", model.StartDate),
                new SqlParameter("@EndDate", model.EndDate),
                new SqlParameter("@Location", model.Location),
                new SqlParameter("@LocationType", model.LocationType),
                new SqlParameter("@Description", model.Description),
            };
                await _experienceService.UpdateExperience("SP_Put_Experience", sp);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

