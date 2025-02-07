using Database;
using Entities.Models;
using Microsoft.Data.SqlClient;

namespace EPortalAPI.Services
{
    public class PersonalProfileService : IPersonalProfileService
    {
        public async Task<List<PersonalProfileModel>> PersonalProfileModels(string procedureName)
        {
            try
            {
                return await DALCRUD.GetEntitiesFromReadDataAsync<PersonalProfileModel>(procedureName);
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

        public async Task<PersonalProfileModel> PersonalProfileModel(string procedureName, SqlParameter[] sp)
        {
            try
            {
                var result = await DALCRUD.GetEntitiesFromReadDataAsync<PersonalProfileModel>(procedureName, sp);
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

        public async Task CreatePersonalProfileModel(string procedureName, SqlParameter[] sp)
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

        public async Task UpdatePersonalProfileModel(string procedureName, SqlParameter[] sp)
        {
            try
            {
                await DALCRUD.UpdateInfo<PersonalProfileModel>(procedureName, sp);
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

        public async Task DeletePersonalProfileModel(string procedureName, SqlParameter[] sp)
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

