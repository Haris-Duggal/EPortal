using Database;
using Entities.Models;
using Microsoft.Data.SqlClient;

namespace EPortalAPI.Services
{
    public class TeachingSkillService : ITeachingSkillService
    {
        public async Task<List<SkillModel>> GetTeachingSkillModels(string procedureName)
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

        public async Task<List<SkillModel>> GetTeachingSkillModel(string procedureName, SqlParameter[] sp)
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

        public async Task CreateTeachingSkillModel(string procedureName, SqlParameter[] sp)
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

        public async Task UpdateTeachingSkillModel(string procedureName, SqlParameter[] sp)
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

        public async Task DeleteTeachingSkillModel(string procedureName, SqlParameter[] sp)
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
