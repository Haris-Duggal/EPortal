using Entities.DTOs;
using Entities.DTOMappers;
using EPortalAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Entities.Models;

namespace EPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachingSkillController : ControllerBase
    {
        private readonly ITeachingSkillService _teachingSkillService;

        public TeachingSkillController(ITeachingSkillService teachingSkillService)
        {
            _teachingSkillService = teachingSkillService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SkillDTO>>> GetTeachingSkillModels()
        {
            try
            {
                var result = await _teachingSkillService.GetTeachingSkillModels("SP_Get_TeachingSkills");
                return Ok(result.Select(static model => model.ToDTO()).ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<SkillModel>>> GetTeachingSkillModel(string userId)
        {
            try
            {
                SqlParameter[] sp =
                {
                    new SqlParameter("@fk_UserID", userId)
                };
                var result = await _teachingSkillService.GetTeachingSkillModel("SP_Get_TeachingSkillsById", sp);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateTeachingSkillModel(CreateSkillDTO createSkillDTO)
        {
            try
            {
                var teachingSkillModel = createSkillDTO.ToModel();
                SqlParameter[] sp =
                {
                    new SqlParameter("@fk_UserID", "911"),
                    new SqlParameter("@SkillName", teachingSkillModel.SkillName),
                    new SqlParameter("@TimeDuration", teachingSkillModel.TimeDuration)
                };
                await _teachingSkillService.CreateTeachingSkillModel("SP_Post_TeachingSkill", sp);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{SkillID}")]
        public async Task<ActionResult> UpdateTeachingSkillModel(SkillModel model)
        {
            try
            {
                
                SqlParameter[] sp =
                {
                    new SqlParameter("@SkillID", model.SkillID),
                    new SqlParameter("@SkillName", model.SkillName),
                    new SqlParameter("@TimeDuration", model.TimeDuration)
                };
                await _teachingSkillService.UpdateTeachingSkillModel("SP_Put_TeachingSkill", sp);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteTeachingSkillModel(int Id)
        {
            try
            {
                SqlParameter[] sp =
                {
                    new SqlParameter("@SkillID", Id)
                };
                await _teachingSkillService.DeleteTeachingSkillModel("SP_Delete_TeachingSkill", sp);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}


