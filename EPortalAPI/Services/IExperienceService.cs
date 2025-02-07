using Entities.Models;
using Microsoft.Data.SqlClient;

namespace EPortal.Services
{
    public interface IExperienceService
    {
        Task<List<ExperienceModel>> GetExperienceModels(string procedureName);
        Task<List<ExperienceModel>> GetExperienceModel(string procedureName, SqlParameter [] sp);
        Task AddExperience(string procedureName, SqlParameter[] sp );
        Task RemoveExperience(string procedureName, SqlParameter[] sp);
        Task UpdateExperience(string procedureName , SqlParameter[] sp);
    }
}