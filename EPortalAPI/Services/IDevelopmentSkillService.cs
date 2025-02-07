using Entities.Models;
using Microsoft.Data.SqlClient;

namespace EPortalAPI.Services
{
    public interface IDevelopmentSkillService
    {
        Task<List<SkillModel>> GetDevelopmentSkillModels(string ProcedureName);
        Task<List<SkillModel>> GetDevelopmentSkillModel(string procedureName, SqlParameter[] sp);
        Task CreateDevelopmentSkillModel(string procedureName, SqlParameter[] sp);
        Task UpdateDevelopmentSkillModel(string procedureName, SqlParameter[] sp);
        Task DeleteDevelopmentSkillModel(string procedureName, SqlParameter[] sp);
    }
}
