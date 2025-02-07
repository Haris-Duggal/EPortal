using Entities.Models;
using Microsoft.Data.SqlClient;

namespace EPortalAPI.Services
{
    public interface ITeachingSkillService
    {
        Task<List<SkillModel>> GetTeachingSkillModels(string procedureName);
        Task<List<SkillModel>> GetTeachingSkillModel(string procedureName, SqlParameter[] sp);
        Task CreateTeachingSkillModel(string procedureName, SqlParameter[] sp);
        Task UpdateTeachingSkillModel(string procedureName, SqlParameter[] sp);
        Task DeleteTeachingSkillModel(string procedureName, SqlParameter[] sp);
    }
}
