using Entities.Models;
using Microsoft.Data.SqlClient;

namespace EPortal.Services
{
    public interface IEducationService
    {
        Task AddEducation(string procedureName, SqlParameter[] sp);
        Task<List<EducationModel>> GetAllEducation(string procedureName);
        Task UpdateEducation(string procedureName, SqlParameter[] sp );
        Task DeleteEducation(string procedureName, SqlParameter[]sp);
        Task<List<EducationModel>> GetEducationByID(string procedureName, SqlParameter[] sp);
    }
}
