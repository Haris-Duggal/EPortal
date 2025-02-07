using Entities.DTOs;
using Entities.DTOMappers;
using EPortal.Services;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace EPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IEducationService _educationService;

        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EducationDTO>>> GetEducation()
        {
            try
            {
                var result = await _educationService.GetAllEducation("SP_Get_Education");
                return Ok(result.Select(static model => model.ToDTO()).ToList());
            }
            catch (SqlException ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddEducation(CreateEducationDTO createEducationDTO)
        {
            try
            {
                var model = createEducationDTO.ToModel();
                SqlParameter[] sp =
                {
                    new SqlParameter("@fk_UserID", "911"),
                    new SqlParameter("@InstituteName", model.InstituteName),
                    new SqlParameter("@Degree", model.Degree),
                    new SqlParameter("@FieldOfStudy", model.FieldOfStudy),
                    new SqlParameter("@StartDate", model.StartDate),
                    new SqlParameter("@EndDate", model.EndDate),
                    new SqlParameter("@Range", model.Range)
                };

                await _educationService.AddEducation("SP_Post_Education", sp);
                return Ok();
            }
            catch (SqlException ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEducation(UpdateEducationDTO updateEducationDTO)
        {
            try
            {
                var model = updateEducationDTO.ToModel();
                SqlParameter[] sp =
                {
                    new SqlParameter("@EducationID", model.EducationID),
                    new SqlParameter("@InstituteName", model.InstituteName),
                    new SqlParameter("@Degree", model.Degree),
                    new SqlParameter("@FieldOfStudy", model.FieldOfStudy),
                    new SqlParameter("@StartDate", model.StartDate),
                    new SqlParameter("@EndDate", model.EndDate),
                    new SqlParameter("@Range", model.Range)
                };
                await _educationService.UpdateEducation("SP_Put_Education", sp);
                return Ok();
            }
            catch (SqlException ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEducation(int id)
        {
            try
            {
                SqlParameter[] sp =
                {
                    new SqlParameter("EducationID", id),
                };
                await _educationService.DeleteEducation("SP_Delete_Education", sp);
                return Ok();
            }
            catch (SqlException ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EducationDTO>> GetEducationByID(string id)
        {
            try
            {
                SqlParameter[] sp =
                {
                    new SqlParameter("fk_UserID", id)
                };
                var education = await _educationService.GetEducationByID("SP_Get_EducationById", sp);
                return Ok(education.Select(static model => model.ToDTO()).ToList());
            }
            catch (SqlException ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
