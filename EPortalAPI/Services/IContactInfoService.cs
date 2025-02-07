using Entities.Models;
using Microsoft.Data.SqlClient;

namespace EPortalAPI.Services
{
    public interface IContactInfoService
    {
        Task<List<ContactInfoModel>> ContactInfoModels(string procedure);
        Task<ContactInfoModel> ContactInfoModel(string procedureName, SqlParameter[] sp);
        Task CreateContactInfoModel(string procedureName, SqlParameter[] sp);
        Task UpdateContactInfoModel(string procedureName, SqlParameter[] sp);
        Task DeleteContactInfoModel(string procedureName, SqlParameter[] sp);
    }
}
