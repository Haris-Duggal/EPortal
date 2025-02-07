using Database;
using Entities.Models;
using Microsoft.Data.SqlClient;

namespace EPortal.Services
{
    public class ExperienceService : IExperienceService
    {

        public async Task<List<ExperienceModel>> GetExperienceModels(string procedureName)
        {
            try
            {
                return await DALCRUD.GetEntitiesFromReadDataAsync<ExperienceModel>(procedureName);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return null!;
            }
        }

        public async Task<List<ExperienceModel>> GetExperienceModel(string procedureName, SqlParameter[] sp)
        {
            try
            {
                List<ExperienceModel> experiences =await DALCRUD.GetEntitiesFromReadDataAsync<ExperienceModel>(procedureName, sp);
                return experiences;

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return null!;
            }
        }

        public async Task AddExperience(string procedureName, SqlParameter[] sp)
        {
            try
            {
                await DALCRUD.AddData(procedureName, sp);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }

        public async Task RemoveExperience(string procedureName, SqlParameter[] sp)
        {
            try
            {
                await DALCRUD.DeleteInfo(procedureName, sp);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }

        public async Task UpdateExperience(string procedureName, SqlParameter[] sp)
        {
            try
            {
                await DALCRUD.UpdateInfo<ExperienceModel>(procedureName, sp);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}