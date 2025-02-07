using Entities.Models;
using Microsoft.Data.SqlClient;

namespace EPortalAPI.Services
{
    public interface IPersonalProfileService
    {
        Task<List<PersonalProfileModel>> PersonalProfileModels(string procedureName);
        Task<PersonalProfileModel> PersonalProfileModel(string procedureName, SqlParameter[] sp);
        Task CreatePersonalProfileModel(string procedureName, SqlParameter[] sp);
        Task UpdatePersonalProfileModel(string procedureName, SqlParameter[] sp);
        Task DeletePersonalProfileModel(string procedureName, SqlParameter[] sp);
    }
}
