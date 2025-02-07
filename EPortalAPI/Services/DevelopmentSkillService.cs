using Database;
using Entities.Models;
using Microsoft.Data.SqlClient;

namespace EPortalAPI.Services
{
    public class DevelopmentSkillService : IDevelopmentSkillService
    {
        public async Task<List<SkillModel>> GetDevelopmentSkillModels(string procedureName)
        {
            try
            {
                return await DALCRUD.GetEntitiesFromReadDataAsync<SkillModel>(procedureName);
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

        public async Task<List<SkillModel>> GetDevelopmentSkillModel(string procedureName, SqlParameter[] sp)
        {
            try
            {
                return await DALCRUD.GetEntitiesFromReadDataAsync<SkillModel>(procedureName, sp);
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

        public async Task CreateDevelopmentSkillModel(string procedureName, SqlParameter[] sp)
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

        public async Task UpdateDevelopmentSkillModel(string procedureName, SqlParameter[] sp)
        {
            try
            {
                await DALCRUD.UpdateInfo<SkillModel>(procedureName, sp);
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

        public async Task DeleteDevelopmentSkillModel(string procedureName, SqlParameter[] sp)
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
