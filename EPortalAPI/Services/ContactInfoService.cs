using Database;
using Entities.Models;
using Microsoft.Data.SqlClient;

namespace EPortalAPI.Services
{
    /// <summary>
    /// ContactInfoService.
    /// </summary>
    public class ContactInfoService : IContactInfoService
    {
        /// <summary>
        /// ContactInfoModels,
        /// </summary>
        /// <param name="procedureName"></param>
        /// <returns></returns>
        public async Task<List<ContactInfoModel>> ContactInfoModels(string procedureName)
        {
            try
            {
                return await DALCRUD.GetEntitiesFromReadDataAsync<ContactInfoModel>(procedureName);
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"SQL Error: {sqlEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<ContactInfoModel> ContactInfoModel(string procedureName, SqlParameter[] sp)
        {
            try
            {
                var result = await DALCRUD.GetEntitiesFromReadDataAsync<ContactInfoModel>(procedureName, sp);
                return result.FirstOrDefault()!;
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"SQL Error: {sqlEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task CreateContactInfoModel(string procedureName, SqlParameter[] sp)
        {
            try
            {
                await DALCRUD.AddData(procedureName, sp);
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"SQL Error: {sqlEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateContactInfoModel(string procedureName, SqlParameter[] sp)
        {
            try
            {
                await DALCRUD.UpdateInfo<ContactInfoModel>(procedureName, sp);
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"SQL Error: {sqlEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteContactInfoModel(string procedureName, SqlParameter[] sp)
        {
            try
            {
                await DALCRUD.DeleteInfo(procedureName, sp);
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"SQL Error: {sqlEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
    }
}

