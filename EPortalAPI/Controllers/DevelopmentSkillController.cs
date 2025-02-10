using Entities.DTOs;
using Entities.DTOMappers;
using Entities;
using EPortalAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace EPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopmentSkillController : ControllerBase
    {
        private readonly IDevelopmentSkillService _developmentSkillService;

        public DevelopmentSkillController(IDevelopmentSkillService developmentSkillService)
        {
            _developmentSkillService = developmentSkillService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SkillDTO>>> GetDevelopmentSkillModels()
        {
            try
            {
                var result = await _developmentSkillService.GetDevelopmentSkillModels("SP_Get_DevelopmentSkills");
                return Ok(result.Select(static model => model.ToDTO()).ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<SkillDTO>>> GetDevelopmentSkillModel(string userId)
        {
            try
            {
                SqlParameter[] sp =
                {
                    new SqlParameter("@fk_UserID", userId)
                };
                var result = await _developmentSkillService.GetDevelopmentSkillModel("SP_Get_DevelopmentSkillsById", sp);
                return Ok(result.Select(static model => model.ToDTO()).ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateDevelopmentSkillModel(CreateSkillDTO createSkillDTO)
        {
            try
            {
                var developmentSkillModel = createSkillDTO.ToModel();
                SqlParameter[] sp =
                {
                    new SqlParameter("@fk_UserID", "911"),
                    new SqlParameter("@SkillName", developmentSkillModel.SkillName),
                    new SqlParameter("@TimeDuration", developmentSkillModel.TimeDuration)
                };
                await _developmentSkillService.CreateDevelopmentSkillModel("SP_Post_DevelopmentSkill", sp);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult> UpdateDevelopmentSkillModel(UpdateSkillDTO updateSkillDTO, string userId)
        {
            try
            {
                var developmentSkillModel = updateSkillDTO.ToModel();
                SqlParameter[] sp =
                {
                    new SqlParameter("@fk_UserID", userId),
                    new SqlParameter("@SkillName", developmentSkillModel.SkillName),
                    new SqlParameter("@TimeDuration", developmentSkillModel.TimeDuration)
                };
                await _developmentSkillService.UpdateDevelopmentSkillModel("SP_Put_DevelopmentSkill", sp);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult> DeleteDevelopmentSkillModel(string userId)
        {
            try
            {
                SqlParameter[] sp =
                {
                    new SqlParameter("@fk_UserID", userId)
                };
                await _developmentSkillService.DeleteDevelopmentSkillModel("SP_Delete_DevelopmentSkill", sp);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}


